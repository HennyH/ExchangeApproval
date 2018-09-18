using ExchangeApproval.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using ZNetCS.AspNetCore.Authentication.Basic;
using ZNetCS.AspNetCore.Authentication.Basic.Events;
using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Converters;

namespace ExchangeApproval
{
    public class Startup
    {
        private bool EnableCORS { get; set; } = false;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var corsOrigins = Configuration["server.cors:origins"];
            if (!string.IsNullOrEmpty(corsOrigins))
            {
                services.AddCors(options =>
                {
                    options.AddPolicy(
                        "FromAppSettings",
                        builder => builder
                            .WithOrigins(corsOrigins.Split(";"))
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                    );
                });
                this.EnableCORS = true;
            }

            services.AddScoped<BasicAuthenticationEventHandler>();
            services
                .AddAuthentication(BasicAuthenticationDefaults.AuthenticationScheme)
                .AddBasicAuthentication(options =>
                {
                    options.Realm = "ExchangeApproval";
                    options.EventsType = typeof(BasicAuthenticationEventHandler);
                });

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<ExchangeDbContext>(options =>
            {
                options.UseInMemoryDatabase("ExchangeDb");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (this.EnableCORS)
            {
                app.UseCors("FromAppSettings");
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ExchangeDbContext>();
                db.Database.EnsureCreated();
            }
        }
    }
}
