using System.Text.Json.Serialization;
using ClinicaSaude.Bff.Api.Configurations;
using ClinicaSaude.Bff.Api.Models;
using ClinicaSaude.Bff.Borders.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;

namespace ClinicaSaude.Bff.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;

            // var loggerConfig = new LoggerConfiguration()
            //     .ReadFrom.Configuration(Configuration)
            //     .Enrich.FromLogContext()
            //     // Logs gerados nas rotas de healthcheck devem ser ignorados para evitar de poluir os logs
            //     .Filter.ByExcluding(Matching.WithProperty("RequestPath", "/api/healthcheck"))
            //     .Filter.ByExcluding(Matching.WithProperty("RequestPath", "/api/healthcheck/ping"));


            // Log.Logger = loggerConfig.CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appConfig = Configuration.LoadConfiguration();

            services.AddCors();

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddSingleton(appConfig);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionResultConverter, ActionResultConverter>();
           

            // services.AddUseCases();
            services.AddRepositories();
            services.AddBearerAuthentication(appConfig);
            services.AddOpenApiDocumentation(appConfig);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var appConfig = app.ApplicationServices.GetRequiredService<ApplicationConfig>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-docs/{documentName}/open-api.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api-docs/v1/open-api.json", "ClinicaSaude.Bff.Api v1");
                c.RoutePrefix = "api-docs";
                c.OAuthScopeSeparator(" ");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
