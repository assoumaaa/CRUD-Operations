using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using WebAPI__CodeFirst.Authentication;
using WebAPI__CodeFirst.Classes;
using WebAPI__CodeFirst.Model;
using WebAPI__CodeFirst.Redis;

namespace WebAPI__CodeFirst.Controllers
{

    [Route("api/covid")]
    public class CovidController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDistributedCache _cache;

        public CovidController(IHttpClientFactory httpClientFactory, IDistributedCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _cache = cache;
        }

        [HttpGet]
        public async Task<String> GetSummary()
        {
            var httpClient = _httpClientFactory.CreateClient("covid");
            var response = await httpClient.GetAsync("summary");
            return await response.Content.ReadAsStringAsync();
        }

        [HttpGet("GetAllCountries")]
        public async Task<String> GetAllCountries()
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

        [HttpGet("countries/{country}")]
        public async Task<String> GetByCountry(string country)
        {
            var httpClient = _httpClientFactory.CreateClient("covid");
            var response = await httpClient.GetAsync($"country/{country}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}



/*
       
*/