using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WebAPI__CodeFirst.Services.Interface;

namespace WebAPI__CodeFirst.Services
{
    public class Swagger: IServices
    { 
        public void AddServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Customers Web API",
                    Description = "Testing my swagger"
                });
            });
        }
    }
}

