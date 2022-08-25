using System;
using Microsoft.Extensions.Caching.Distributed;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI__CodeFirst.Redis;

namespace WebAPI__CodeFirst.Repos.CovidRepo
{
    public class CovidRepository: ICovidRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDistributedCache _cache;

        public CovidRepository( IHttpClientFactory httpClientFactory, IDistributedCache cache ) 
        {
            _cache = cache;
            _httpClientFactory = httpClientFactory;
        }
 
        public async Task<string> GetSummaryAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("covid");
            var response = await httpClient.GetAsync("summary");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAllCountriesAsync()
        {
            string recordKey = "Countries_getAll";
            var cachedContries = await _cache.GetRecordAsync<String>(recordKey);

            if (cachedContries is null)
            {
                var httpClient = _httpClientFactory.CreateClient("covid");

                var response = await httpClient.GetAsync("countries");

                var resposneString = await response.Content.ReadAsStringAsync();

                await _cache.SetRecordAsync(recordKey, resposneString);

                Console.Write("LOADED FROM API!\n");

                return resposneString;
            }
            else
            {
                Console.Write("LOADED FROM CACHE!\n");

                return cachedContries;
            }
        }

        public async Task<string> GetByCountryAsync(string country)
        {
            var httpClient = _httpClientFactory.CreateClient("covid");
            var response = await httpClient.GetAsync($"country/{country}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
    



