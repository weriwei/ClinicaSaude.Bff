using ClinicaSaude.Bff.Borders.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaSaude.Bff.Api.Configurations
{
    public static class ValidatorsConfig
    {
        public static IServiceCollection AddValidators(this IServiceCollection services) =>
            services.AddSingleton<UserSignupRequestValidator>()
                    .AddSingleton<AddressValidator>()
                    .AddSingleton<ZipCodeValidator>()
                    .AddSingleton<UserLoginRequestValidator>()
                    .AddSingleton<EmailValidator>();
    }
}
