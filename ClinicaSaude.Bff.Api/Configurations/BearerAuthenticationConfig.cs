using ClinicaSaude.Bff.Borders.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaSaude.Bff.Api.Configurations
{
    public static class BearerAuthenticationConfig
    {
        public static IServiceCollection AddBearerAuthentication(this IServiceCollection services, ApplicationConfig applicationConfig)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = applicationConfig.Authentication.Authority.ToString();
                    options.Audience = applicationConfig.Authentication.Audience;
                });

            return services;
        }
    }
}
