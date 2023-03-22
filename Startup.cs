using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyCompany.Service;

namespace MyCompany
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) =>Configuration= configuration;


        public void ConfigureServices(IServiceCollection services)
        {
            // подключаем конфиг из аппсеттингс
            Configuration.Bind("Project",new Config());

            // добавляем поддержку контроллеров
            services.AddControllersWithViews()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // порядок регистрации middleware очень важен

            // в процессе девелопа важно знать подробно об ошибках 

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // включаем поддержку статитчных файлов css js and etc.
            app.UseStaticFiles();

            // Register needing routing
            app.UseEndpoints(endpoints =>
            {
               endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            });
            
        }
    }
}
