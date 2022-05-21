using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.UseCases.Appointment;
using ClinicaSaude.Bff.UseCases.CreateDependent;
using ClinicaSaude.Bff.UseCases.Doctor;
using ClinicaSaude.Bff.UseCases.GetDependent;
using ClinicaSaude.Bff.UseCases.Schedule;
using ClinicaSaude.Bff.UseCases.Speciality;
using ClinicaSaude.Bff.UseCases.UserLogin;
using ClinicaSaude.Bff.UseCases.UserSignup;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaSaude.Bff.Api.Configurations
{
    public static class UseCasesConfig
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services) =>
            services.AddSingleton<IUserSignupUseCase, UserSignupUseCase>()
                    .AddSingleton<IUserLoginUseCase, UserLoginUseCase>()
                    .AddSingleton<IGetDependentUseCase, GetDependentUseCase>()
                    .AddSingleton<ICreateDependentUseCase, CreateDependentUseCase>()
                    .AddSingleton<IGetSpecialitysUseCase, GetSpecialitysUseCase>()
                    .AddSingleton<IGetDoctorsUseCase, GetDoctorsUseCase>()
                    .AddSingleton<IGetSchedulesUseCase, GetSchedulesUseCase>()
                    .AddSingleton<ICreateAppointmentUseCase, CreateAppointmentUseCase>()
                    .AddSingleton<IGetAppointmentsUseCase, GetAppointmentsUseCase>();
    }
}
