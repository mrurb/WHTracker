using Microsoft.Extensions.Configuration;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using WHTracker.Options;
using WHTracker.Services.Models;

namespace WHTracker.Services
{
    internal class ZKillRedisQAPIService
    {
        private readonly HttpClient client;
        private readonly Zkillsettings zkillsettings;

        public ZKillRedisQAPIService(HttpClient httpClient, IConfiguration configuration)
        {
            zkillsettings = configuration.GetSection("Zkillsettings").Get<Zkillsettings>();


            httpClient.BaseAddress = new Uri(zkillsettings.RedisQEndpoint);

            httpClient.DefaultRequestHeaders.Add("User-Agent", "WHTracker");

            this.client = httpClient;
        }


        public async Task<RedisQZkill> GetRedisQCall()
        {
            HttpResponseMessage response = await client.GetAsync($"/listen.php?queueID={zkillsettings.QueueID}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<RedisQZkill>(responseStream);
        }
    }
}