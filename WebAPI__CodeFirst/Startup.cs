using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WebAPI__CodeFirst.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI__CodeFirst.Repos;
using WebAPI__CodeFirst.Model;
using System.Text;
using Serilog;
using System;
using WebAPI__CodeFirst.Repos.CovidRepo;
using WebAPI__CodeFirst.Repos.UserRepo;
using WebAPI__CodeFirst.Services.Extension;

namespace WebAPI__CodeFirst
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;       
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.GetAllServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customers Web API");
                c.RoutePrefix = String.Empty;
            });

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseCors(
                 options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
