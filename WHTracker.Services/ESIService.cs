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
    }
}
