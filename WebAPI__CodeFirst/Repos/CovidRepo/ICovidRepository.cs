using System;
using System.Threading.Tasks;

namespace WebAPI__CodeFirst.Repos.CovidRepo
{
    public interface ICovidRepository
    {
        Task<String> GetSummaryAsync();

        Task<String> GetAllCountriesAsync();

        Task<String> GetByCountryAsync(string country);
    }
}

