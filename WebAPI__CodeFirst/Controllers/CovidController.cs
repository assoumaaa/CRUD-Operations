using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI__CodeFirst.Authentication;
using WebAPI__CodeFirst.Model;

namespace WebAPI__CodeFirst.Controllers
{

    [Route("api/covid")]
    public class CovidController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CovidController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
            var httpClient = _httpClientFactory.CreateClient("covid");
            var response = await httpClient.GetAsync("countries");
            return await response.Content.ReadAsStringAsync();
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
