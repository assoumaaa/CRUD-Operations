using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI__CodeFirst.Services.Interface;

namespace WebAPI__CodeFirst.Services.Extension
{
    public static class ServicesExtension
    {
        public static void GetAllServices(this IServiceCollection services, IConfiguration configuration)
        {
            var allServices = typeof(Startup).Assembly.ExportedTypes
                .Where(installer => typeof(IServices).IsAssignableFrom(installer) && !installer.IsInterface && !installer.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IServices>().ToList();

            allServices.ForEach(installer => installer.AddServices(services, configuration));
        }
    }
}

