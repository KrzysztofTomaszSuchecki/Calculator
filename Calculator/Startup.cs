using CalculatorDataLayer.Data;
using CalculatorDataLayer.Interface;
using CalculatorDataLayer.Model;
using CalculatorDataLayer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CalculatorDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CalculatorDbConnectionString")));
            services.AddControllers();
            services.AddHttpClient();
            services.AddTransient<IRepositoryOperation<Operation>, RepositoryOperation>();
            services.AddTransient<IRepositoryOperaionsTypes<OperaionsTypes>, RepositoryOperation>();
            services.AddTransient<OperationService, OperationService>();
            services.AddControllers();
            services.AddMvc();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {


                //endpoints.MapControllerRoute(
                //     name: "oper",
                //     pattern: "oper/{id?}/{no1?}/{no2?}",
                //     defaults: new { controller = "Home", action = "Oper" });
                endpoints.MapControllers();
                endpoints.MapControllerRoute("calc",
                             "calc/{id?}/{no1?}/{no2?}",
                             defaults: new { controller = "Home", action = "Calc" });
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Getall}/{id?}");
                //endpoints.MapControllerRoute(
                //    name: "delete",
                //    pattern: "{controller=Home}/{action=Delete}/delete/{id?}");
                //endpoints.MapControllerRoute(
                //    name: "calculator",
                //    pattern: "{controller=Home}/{action=Calculator}");
                //endpoints.MapControllerRoute(
                //    name: "oper",
                //    pattern: "{controller=Home}/{action=Oper}");
                //endpoints.MapControllerRoute(
                //    name: "oper",
                //    pattern: "{oper}/{id?}/{no1?}/{no2?}");
            });
        }
    }
}
