using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI__CodeFirst.Repos;
using WebAPI__CodeFirst.Repos.CovidRepo;
using WebAPI__CodeFirst.Repos.UserRepo;
using WebAPI__CodeFirst.Services.Interface;

namespace WebAPI__CodeFirst.Services
{
    public class Repo: IServices 
    {
        public void AddServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<ICovidRepository, CovidRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

