using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace web.api
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

            services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());

            //services.AddOpenTelemetryTracing((builder) =>
            //{
            //    builder
            //        .AddAspNetCoreInstrumentation()
            //        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("OcelotApiGw"))
            //        .AddHttpClientInstrumentation()
            //        .AddSource(nameof(IOcelotBuilder))
            //        .AddJaegerExporter(options =>
            //        {
            //            options.AgentHost = "localhost";
            //            options.AgentPort = 6831;
            //            options.ExportProcessorType = ExportProcessorType.Simple;
            //        })
            //        .AddConsoleExporter(options =>
            //        {
            //            options.Targets = ConsoleExporterOutputTargets.Console;
            //        });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            await app.UseOcelot();
        }
    }
}
