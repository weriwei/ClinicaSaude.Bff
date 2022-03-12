using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos.HealthCheck;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases.HealthCheck;

namespace ClinicaSaude.Bff.UseCases.HealthCheck
{
    public class GetHealthCheckStatusUseCase : IGetHealthCheckStatusUseCase
    {
        private readonly IDatabaseRepository databaseRepository;

        public GetHealthCheckStatusUseCase(
            IDatabaseRepository databaseRepository
        )
        {
            this.databaseRepository = databaseRepository;
        }

        public async Task<UseCaseResponse<HealthCheckStatus>> Execute()
        {
            var response = new UseCaseResponse<HealthCheckStatus>();
            
            var databaseHealthTask = databaseRepository.CheckHealth();

            var activities = new HealthCheckActivity[]
            {
                new(Name: "Database", Success: await databaseHealthTask)
            };
            var status = new HealthCheckStatus("1.0.0.0", activities);
            
            return status.Success
                ? response.SetSuccess(status)
                : response.SetUnavailable(status);
        }
    }
}