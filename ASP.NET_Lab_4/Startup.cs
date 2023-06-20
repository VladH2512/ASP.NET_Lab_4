using ASP.NET_Lab_4.Data.Interfaces;
using ASP.NET_Lab_4.Data;
using ASP.NET_Lab_4.Data.Repository;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Lab_4.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace ASP.NET_Lab_4
{

    public class Startup
    {
        private IConfigurationRoot _confString;
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllClothes, ClothesRepository>();
            services.AddTransient<IClothesCategory, CategoryRepository>();
            services.AddTransient<IClothesTypes, TypesRepository>();
            services.AddTransient<IClothesCompany, CompanyRepository>();
            services.AddTransient<IClothesColor, ColorRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();

            app.UseMvcWithDefaultRoute();
           
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller-Home}/{action-Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Clothes/{action}/{category?}", defaults: new
                {
                    Controller = "Clothes",
                    action = "List"
                });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();


        }

    }
}
