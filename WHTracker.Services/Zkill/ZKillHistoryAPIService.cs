using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using WHTracker.Options;

namespace WHTracker.Services
{
    public class ZKillHistoryAPIService
    {
        private readonly HttpClient client;
        private readonly Zkillsettings zkillsettings;

        public ZKillHistoryAPIService(HttpClient httpClient, IConfiguration configuration)
        {
            zkillsettings = configuration.GetSection("Zkillsettings").Get<Zkillsettings>();


            httpClient.BaseAddress = new Uri(zkillsettings.ZkillEndpoint);

            httpClient.DefaultRequestHeaders.Add("User-Agent", "WHTracker");

            this.client = httpClient;
        }


        public async Task<Dictionary<int, string>> GetHistoryData(DateTime date)
        {
            string requestUri = $"/api/history/{date:yyyyMMdd}.json";
            HttpResponseMessage response = await client.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            Dictionary<int, string> hashData = await JsonSerializer.DeserializeAsync<Dictionary<int, string>>(responseStream);
            return hashData;
        }
    }
}
