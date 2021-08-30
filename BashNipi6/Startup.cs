using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BashNipi6.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BashNipi6
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string connnectionPath = @"Server=.\SQLEXPRESS;Database=BashNipi2;Trusted_Connection=True;";
            services.AddDbContext<ProjectsContext>(options => options.UseSqlServer(connnectionPath));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
            });
        }
    }
}
