using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using WHTracker.Options;
using WHTracker.Services.Cache;
using WHTracker.Services.Models;

namespace WHTracker.Services
{
    public static class ESICacheKeys
    {
        public static string TypeData { get { return "ESI::Cache::TypeData::"; } }
        public static string MarketData { get { return "ESI::Cache::MarketData::"; } }
    }

    public class ESIService
    {
        private readonly HttpClient client;
        private readonly ESISettings eSIsettings;
        private readonly IMemoryCache memoryCache;

        public ESIService(HttpClient httpClient, IConfiguration configuration, IMemoryCache memoryCache)
        {
            eSIsettings = configuration.GetSection("ESISettings").Get<ESISettings>();


            httpClient.BaseAddress = new Uri(eSIsettings.BaseUrl);

            httpClient.DefaultRequestHeaders.Add("User-Agent", "WHTracker");

            this.client = httpClient;
            this.memoryCache = memoryCache;
        }


        public async Task<SolarSystem> GetSolarSystem(int systemId)
        {
            string requestUri = $"/v4/universe/systems/{systemId}/";
            HttpResponseMessage response = await client.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            SolarSystem solarSystem = await JsonSerializer.DeserializeAsync<SolarSystem>(responseStream);
            return solarSystem;
        }

        public async Task<Corporation> GetCorporation(int corporationId)
        {
            string requestUri = $"/v4/corporations/{corporationId}/";
            HttpResponseMessage response = await client.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            Corporation corporation = await JsonSerializer.DeserializeAsync<Corporation>(responseStream);
            return corporation;
        }

        public async Task<Alliance> GetAlliance(int allianceId)
        {
            string requestUri = $"/v4/alliances/{allianceId}/";
            HttpResponseMessage response = await client.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            Alliance alliance = await JsonSerializer.DeserializeAsync<Alliance>(responseStream);
            return alliance;
        }

        public async Task<IEnumerable<int>> GetAllianceCorporations(int allianceId)
        {
            string requestUri = $"/v2/alliances/{allianceId}/corporations/";
            HttpResponseMessage response = await client.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            IEnumerable<int> corporationIds = await JsonSerializer.DeserializeAsync<IEnumerable<int>>(responseStream);
            return corporationIds;
        }

        public async Task<int> GetAllianceMemberCount(int allianceId)
        {
            IEnumerable<int> corps = await GetAllianceCorporations(allianceId);
            int members = 0;
            foreach (var corp in corps)
            {
                var corpData = await GetCorporation(corp);
                members += corpData.MemberCount;
            }
            return members;
        }

        public async Task<Killmail> GetKillmail(int killmailId, string killmailHash)
        {
            string requestUri = $"/v1/killmails/{killmailId}/{killmailHash}/";
            HttpResponseMessage response = await client.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            Killmail killmail = await JsonSerializer.DeserializeAsync<Killmail>(responseStream);
            return killmail;
        }

        public async Task<EveType> GetEveType(int typeId)
        {
            EveType cachedType;

            string cacheKey = ESICacheKeys.TypeData + typeId;

            if (!memoryCache.TryGetValue(cacheKey, out cachedType))
            {

                string requestUri = $"/v3/universe/types/{typeId}/";
                HttpResponseMessage response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();
                cachedType = await JsonSerializer.DeserializeAsync<EveType>(responseStream);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(1));

                memoryCache.Set(cacheKey, cachedType, cacheEntryOptions);
            }

            return cachedType;
        }

        public async Task<IEnumerable<MarketHistoryData>> GetMarketHistory(int typeId)
        {
            IEnumerable<MarketHistoryData> cachedMarketData;

            string cacheKey = ESICacheKeys.MarketData + typeId;

            if (!memoryCache.TryGetValue(cacheKey, out cachedMarketData))
            {

                int regionId = this.eSIsettings.MarketRegion;

                string requestUri = $"/v1/markets/{regionId}/history/?type_id={typeId}";
                HttpResponseMessage response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();
                cachedMarketData = await JsonSerializer.DeserializeAsync<IEnumerable<MarketHistoryData>>(responseStream);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(1));

                memoryCache.Set(cacheKey, cachedMarketData, cacheEntryOptions);
            }

            return cachedMarketData;
        }

        public async Task<MarketHistoryData> GetMarketHistoryPoint(int typeId, DateTime date)
        {
            var marketData = await GetMarketHistory(typeId);

            if(date > marketData.Min(d => d.Date))
            {
                return marketData.Where(d => d.Date < date).OrderByDescending(d => d.Date).First();
            }
            else
            {
                return marketData.OrderBy(d => d.Date).First();
            }
        }
    }
}
