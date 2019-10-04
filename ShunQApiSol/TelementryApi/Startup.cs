using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessCore.AppHandlers;
using BusinessCore.DataAccess;
using BusinessCore;
using BusinessCore.Services;
using BusinessCore.Services.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Authorization;
using BusinessCore.AppHandlers.Contracts;
using BusinessCore.Infrastructure.Caching;

namespace TelementryApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }


        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

            HostingEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var isProduction = HostingEnvironment.IsProduction();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //inject IOptions<T>
            services.AddOptions();
            // Add our Config object so it can be injected
            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));

            var appConfig = Configuration.GetSection("AppConfig").Get<AppConfig>();
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShunQ API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin().AllowCredentials().AllowAnyMethod().AllowAnyHeader());
            });

            var connection = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=shunqApi-db;Integrated Security=True;MultipleActiveResultSets=False;Connection Timeout=30;";

            if (isProduction)
            {
                connection = @"Server=tcp:shunq-dbserver-dev-v1.database.windows.net,1433;Initial Catalog=shunqApi-db;Persist Security Info=False;User ID=grsadmin;Password=EJBdBpiHJia8FErpu*)OCnTr;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }

            if (isProduction)
            {
                var logger = new AzureLogService(appConfig.LogStorageAccount);
                logger.EnsureTableExists();
                services.AddSingleton(typeof(ILoggerManager), logger);
            }
            else
                services.AddSingleton(typeof(ILoggerManager), new MyLocalLogService(AppContext.BaseDirectory + "shunq-logs.txt"));

            services.AddSingleton(typeof(ICacheManager), new RedisCacheClient(appConfig.RedisConnectionString, appConfig.CachingEnabled));
            services.AddSingleton(typeof(IAdminService), new AdminService(connection));
            services.AddTransient(typeof(IMembershipService), typeof(MembershipService));
            services.AddTransient(typeof(IStoreService), typeof(StoreService));
            services.AddTransient(typeof(IEmailGateway), typeof(GmailGateway));
            services.AddTransient(typeof(ISmsGateway), typeof(SmsGateway));

            services.AddDbContext<CoreDbContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerManager logger, IOptions<AppConfig> appConfig)
        {
            appConfig.Value.Environment = env.EnvironmentName;

            if (env.IsDevelopment())
            {
                app.ConfigureGlobaleException();
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                app.ConfigureGlobaleException();
            }

            //Add  log middleware to the pipeline
            app.UseMiddleware<RequestLogMiddleware>(appConfig.Value.RequestLogLevel);

            if (appConfig.Value.AuthorizationEnabled)
            {
                app.UseAuthentication();
            }
            else
            {
                app.Use(async (context, next) =>
                {
                    context.User = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(Array.Empty<System.Security.Claims.Claim>(), "test"));
                    await next.Invoke();
                });
            }
            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShunQ API v1");
                c.RoutePrefix = string.Empty;
            });


            app.UseMvc();
        }
    }
}
