using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI__CodeFirst.Services.Interface;

namespace WebAPI__CodeFirst.Services
{
    public class Others: IServices 
    {
        public void AddServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddCors();

            services.AddMvc();
        }
    }
}

