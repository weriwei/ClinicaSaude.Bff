using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.Dtos.HealthCheck;

namespace ClinicaSaude.Bff.Borders.UseCases.HealthCheck
{
    public interface IGetHealthCheckStatusUseCase : IUseCaseOnlyResponse<HealthCheckStatus>
    {
        
    }
}