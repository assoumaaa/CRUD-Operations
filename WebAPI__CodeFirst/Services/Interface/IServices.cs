using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI__CodeFirst.Services.Interface
{
    public interface IServices
    {
        void AddServices(IServiceCollection services, IConfiguration Configuration);
    }
}

