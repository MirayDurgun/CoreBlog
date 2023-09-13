using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreBlog
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
            //Identity
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireUppercase = false; //büyük harf mecburiyeti kalkar
                x.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<Context>();


            services.AddControllersWithViews();

            services.AddSession();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            //bu kod sayesinde proje seviyesinde authorize iþlemi kullanabileceðiz

            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                    //return url yapmýþ olduk
                }
                );

            services.ConfigureApplicationCookie(options =>
            //ConfigureApplicationCookie kimlik doðrulama için kullanýlan çerez ayarlarýný yapýlandýrmak için kullanýlan bir seçenekleri kabul eder
            {
                //Cookie Settings
                options.Cookie.HttpOnly = true; //çerezlerin tarayýcý tarafýndan sadece HTTP istekleri ile eriþilebilir olmasýný saðlar
                options.ExpireTimeSpan = TimeSpan.FromMinutes(100); // çerezlerin ne kadar süre boyunca geçerli olacaðýný belirtir
                options.LoginPath = "/Login/Index"; // kimlik doðrulama iþlemi gerektiðinde kullanýcýnýn yönlendirileceði giriþ sayfasýnýn yolunu belirtir
                options.SlidingExpiration = true; //çerezin süresinin otomatik olarak uzatýlmasýný saðlar
            });

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
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1/", "?code={0}");
            //durum kodlarý sayfasýný kullan anlamýnda
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area=exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
