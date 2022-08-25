using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI__CodeFirst.Services.Interface;

namespace WebAPI__CodeFirst.Services
{
    public class Redis:IServices 
    {
        public void AddServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
                options.InstanceName = "Customers";
            });
        }
    }
}

