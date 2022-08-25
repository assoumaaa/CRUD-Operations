using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI__CodeFirst.Model;
using WebAPI__CodeFirst.Services.Interface;

namespace WebAPI__CodeFirst.Services
{
    public class EntityFramework : IServices
    {
        public void AddServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DataContext>(opts => opts.UseSqlServer(Configuration["Data:ConnectionStrings:DefaultConnection"]));

            services.AddDbContext<UserIdentityContext>(opts => opts.UseSqlServer(Configuration["Data:ConnectionStrings:DefaultConnection"]));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UserIdentityContext>();
        }
    }
}

