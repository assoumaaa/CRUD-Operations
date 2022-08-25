using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI__CodeFirst.Services.Interface;

namespace WebAPI__CodeFirst.Services
{
    public class HttpClient : IServices
    {
        public void AddServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpClient();

            services.AddHttpClient("covid", c =>
            {
                c.BaseAddress = new Uri("https://api.covid19api.com/");
            });
        }
    }
}

