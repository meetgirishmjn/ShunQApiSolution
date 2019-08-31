using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessCore.AppHandlers;
using BusinessCore.AppHandlers.Models;
using BusinessCore.Contracts;
using BusinessCore.DataAccess;
using BusinessCore.Models;
using BusinessCore.Services;
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

namespace WebApi
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
            .Build();

            HostingEnvironment = env;
        }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //inject IOptions<T>
            services.AddOptions();
            // Add our Config object so it can be injected
            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));

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

            var connection = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=shunq-db-dev-v1;integrated security=True;MultipleActiveResultSets=False;Connection Timeout=30;";

            if (HostingEnvironment.IsProduction())
            {
                connection = @"Server=tcp:shunq-dbserver-dev-v1.database.windows.net,1433;Initial Catalog=shunq-db-dev-v1;Persist Security Info=False;User ID=grsadmin;Password=EJBdBpiHJia8FErpu*)OCnTr;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }

            services.AddSingleton(typeof(ILoggerManager), typeof(LoggerManager));
            services.AddTransient(typeof(IMembershipService), typeof(MembershipService));

            services.AddDbContext<CoreDbContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerManager logger)
        {
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
