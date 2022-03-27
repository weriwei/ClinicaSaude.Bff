using ClinicaSaude.Bff.Borders.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaSaude.Bff.Api.Configurations
{
    public static class BearerAuthenticationConfig
    {
        public static IServiceCollection AddBearerAuthentication(this IServiceCollection services, ApplicationConfig applicationConfig)
        {

            return services;
        }
    }
}
