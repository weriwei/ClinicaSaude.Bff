using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaSaude.Bff.Api.Configurations
{
    public static class RepositoriesConfig
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IRepositoryHelper, RepositoryHelper>()
                .AddSingleton<IDependentRepository, DependentRepository>();
    }
}
