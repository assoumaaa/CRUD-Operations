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
using WebAPI__CodeFirst.Repos.CovidRepo;

namespace WebAPI__CodeFirst.Controllers
{

    [Route("api/covid")]
    public class CovidController : Controller
    {
        private readonly ICovidRepository _covidRepository;

        public CovidController(ICovidRepository covidRepository)
        {
            _covidRepository = covidRepository;
        }

        [HttpGet]
        public async Task<String> GetSummaryAsync()
        {
            return await _covidRepository.GetSummaryAsync();
        }

        [HttpGet("GetAllCountries")]
        public async Task<String> GetAllCountriesAsync()
        {
            return await _covidRepository.GetAllCountriesAsync();
        }

        [HttpGet("countries/{country}")]
        public async Task<String> GetByCountryAsync(string country)
        {
            return await _covidRepository.GetByCountryAsync(country);
        }
    }
}

