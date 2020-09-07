using Microsoft.Extensions.Configuration;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using WHTracker.Options;
using WHTracker.Services.Models;

namespace WHTracker.Services
{
    public class ZKillRedisQAPIService
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


        public async Task<RedisQZkill> GetRedisQCall(int ttw = 0)
        {
            string requestUri = $"/listen.php?queueID={zkillsettings.QueueID}";
            if (ttw is not 0)
            {
                requestUri += $"&ttw={ttw}";
            }
            HttpResponseMessage response = await client.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            RedisQZkill redisQZkill = await JsonSerializer.DeserializeAsync<RedisQZkill>(responseStream);
            return redisQZkill;
        }
    }
}