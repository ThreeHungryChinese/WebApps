using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MaineCoon.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace MaineCoon {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages().AddRazorPagesOptions(options => {
                //options.Conventions.AuthorizeFolder("/");
                foreach (var role in Enum.GetValues(typeof(Models.User.role))) {
                    //Set Auth Role for every folder
                    options.Conventions.AuthorizeFolder( "/" + role.ToString() , "Is" + role.ToString());
                }
                options.Conventions.AllowAnonymousToPage("/Index");
                options.Conventions.AllowAnonymousToPage("/Signin");
                options.Conventions.AllowAnonymousToPage("/Signup");
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/Signin";
                    options.LogoutPath = "/Account/LogOff";
                    options.ExpireTimeSpan = TimeSpan.FromSeconds(60);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/Signin";
                });

            //Add role Requirements
            services.AddAuthorization(options => {
                foreach (var role in Enum.GetValues(typeof(Models.User.role))) {
                    options.AddPolicy("Is" + role.ToString(), policy =>
                    policy.RequireClaim(ClaimTypes.Role, role.ToString()));

                }
            });

            services.AddDbContext<MaineCoonContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));
            //services.AddSession(options => {
            //    options.IdleTimeout = TimeSpan.FromHours(1);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //});
        }



    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
            });
        }
    }
}
