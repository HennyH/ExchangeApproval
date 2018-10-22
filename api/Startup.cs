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
using ExchangeApproval.AdminTools;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Linq;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace ExchangeApproval
{
    public class Startup
    {
        public static readonly LoggerFactory SqlLoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

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
                var herokuDbUri = Environment.GetEnvironmentVariable("CLEARDB_DATABASE_URL");
                if (herokuDbUri != null)
                {
                    Uri url;
                    Uri.TryCreate(herokuDbUri, UriKind.Absolute, out url);
                    var host = url.Host;
                    var username = url.UserInfo.Split(":").First();
                    var password = url.UserInfo.Split(":").Last();
                    var db = url.LocalPath.TrimStart('/');
                    var connectionString = $"Server={host};Database={db};User={username};Password={password}";
                    options.UseMySql(
                        connectionString,
                        mySqlOptions =>
                        {
                            mySqlOptions.ServerVersion(new Version(5, 5), ServerType.MySql);
                        }
                    );
                }
                else
                {
                    options.UseInMemoryDatabase("ExchangeDb");
                    options.ConfigureWarnings(warningBuilder =>
                    {
                        warningBuilder.Ignore(InMemoryEventId.TransactionIgnoredWarning);
                    });
                    // options.UseLoggerFactory(SqlLoggerFactory);
                }
                options.UseLazyLoadingProxies();
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
                if (env.IsDevelopment() && db.Database.IsSqlite())
                {
                    SeedSampleData.SeedDatabase(db);
                }
                if (db.Database.IsMySql())
                {
                    db.Database.Migrate();
                }
            }
        }
    }
}
