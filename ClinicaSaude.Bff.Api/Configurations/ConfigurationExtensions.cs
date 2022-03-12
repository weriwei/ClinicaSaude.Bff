using ClinicaSaude.Bff.Borders.Shared;
using Microsoft.Extensions.Configuration;

namespace ClinicaSaude.Bff.Api.Configurations
{
    public static class ConfigurationExtensions
    {
        public static ApplicationConfig LoadConfiguration(this IConfiguration source)
        {
            var applicationConfig = source.Get<ApplicationConfig>();

            return applicationConfig;
        }
    }
}