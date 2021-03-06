using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetworkAttackPreventionProject.DAL;
using NetworkAttackPreventionProject.Models;

namespace NetworkAttackPreventionProject
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
                services.AddControllersWithViews();
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Default")));
                services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
                services.Configure<IdentityOptions>(Options =>
                {
                    Options.Password.RequiredLength = 8;
                    Options.Password.RequireNonAlphanumeric = false;
                    Options.Password.RequireLowercase = false;
                    Options.Password.RequireUppercase = false;
                    Options.Password.RequireDigit = true;
                });
                services.AddAuthentication().AddFacebook(options =>
                {
                    options.AppId = "679373123404159";
                    options.AppSecret = "b2f94211c8b1d4cc3ab06b19e65b42de";
                });
                services.AddAuthentication().AddGoogle(options =>
                {
                    options.ClientId = "910103900779-31m21f00r9pirt6fnjs3b63rbja3ehf5.apps.googleusercontent.com";
                    options.ClientSecret = "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";
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
