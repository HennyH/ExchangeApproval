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
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<ExchangeDbContext>(options =>
            {
                var herokuDbUrl = Environment.GetEnvironmentVariable("DATABASE_URL")
                    ?? Environment.GetEnvironmentVariable("JAWS_DB");
                if (herokuDbUrl != null)
                {
                    var (_, connectionString) = DatabaseUrlHelpers.ParseDatabaseUrl(herokuDbUrl);
                    options.UseMySql(connectionString);
                }
                else
                {

                    options.UseInMemoryDatabase("ExchangeDb");
                    options.EnableSensitiveDataLogging();
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
                if (db.Database.IsInMemory())
                {
                    db.Database.EnsureCreated();
                    SeedSampleData.SeedDatabase(db);
                }
                else
                {
                    db.Database.Migrate();
                    db.Add(new StudentApplication
                    {
                        SubmittedAt = DateTime.Now,
                        LastUpdatedAt = DateTime.Now,
                        StudentName = "Henry Hollingworth " + new Random().Next().ToString(),
                        StudentNumber = "21471423",
                        Major1st = "Computer Science",
                        ExchangeUniversityCountry = "Finalnd",
                        ExchangeUniversityHref = "http://finalnd.com",
                        ExchangeUniversityName = "Finland University",
                        UnitSets = new UnitSet[]
                        {
                            new UnitSet
                            {
                                ExchangeUniversityCountry = "Finalnd",
                                ExchangeUniversityHref = "http://finalnd.com",
                                ExchangeUniversityName = "Finland University",
                                IsContextuallyApproved = true,
                                IsEquivalent = null,
                                EquivalentUWAUnitLevel = UWAUnitLevel.Two,
                                ExchangeUnits = new ExchangeUnit[]
                                {
                                    new ExchangeUnit
                                    {
                                        Code = "MATH-HARD",
                                        Title = "The Hardest Math",
                                        Href = "http://hard-math.com"
                                    }
                                },
                                UWAUnits = new UWAUnit[]
                                {
                                    new UWAUnit
                                    {
                                        Code = "MATH-1001",
                                        Title = "Mathematics I",
                                        Href = "http://uwa-unit.com"
                                    },
                                    new UWAUnit
                                    {
                                        Code = "MATH-1002",
                                        Title = "Mathematics II",
                                        Href = "http://uwa-unit.com"
                                    }
                                }
                            }
                        }
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
