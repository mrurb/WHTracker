using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WHTracker.Options;
using WHTracker.Services.Models;

namespace WHTracker.Services
{
    public class ESIService
    {
        private readonly HttpClient client;
        private readonly ESISettings eSIsettings;

        public ESIService(HttpClient httpClient, IConfiguration configuration)
        {
            eSIsettings = configuration.GetSection("ESISettings").Get<ESISettings>();


            httpClient.BaseAddress = new Uri(eSIsettings.BaseUrl);

            httpClient.DefaultRequestHeaders.Add("User-Agent", "WHTracker");

            this.client = httpClient;
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
            foreach(var corp in corps)
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
            string requestUri = $"/v3/universe/types/{typeId}/";
            HttpResponseMessage response = await client.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            EveType type = await JsonSerializer.DeserializeAsync<EveType>(responseStream);
            return type;
        }
    }
}
