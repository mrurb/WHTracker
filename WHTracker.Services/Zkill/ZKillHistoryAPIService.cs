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
            Dictionary<string, string> hashData = await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(responseStream);

            var sanitizedHashData = new Dictionary<int, string>();
            foreach (var item in hashData)
            {
                if(int.TryParse(item.Key, out int id))
                {
                    sanitizedHashData.Add(id, item.Value);
                }
            }

            return sanitizedHashData;
        }
    }
}
