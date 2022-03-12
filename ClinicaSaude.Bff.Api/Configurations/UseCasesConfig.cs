using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.Borders.UseCases.HealthCheck;
using ClinicaSaude.Bff.UseCases.HealthCheck;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaSaude.Bff.Api.Configurations
{
    public static class UseCasesConfig
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services) =>
            services.AddSingleton<IGetHealthCheckStatusUseCase, GetHealthCheckStatusUseCase>();
    }
}