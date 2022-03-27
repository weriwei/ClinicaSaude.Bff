using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.UseCases.UserLogin;
using ClinicaSaude.Bff.UseCases.UserSignup;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaSaude.Bff.Api.Configurations
{
    public static class UseCasesConfig
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services) =>
            services.AddSingleton<IUserSignupUseCase, UserSignupUseCase>()
                    .AddSingleton<IUserLoginUseCase, UserLoginUseCase>();
    }
}
