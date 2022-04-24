using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Shared;

namespace ClinicaSaude.Bff.Borders.UseCases
{
    public interface ICreateDependentUseCase : IUseCase<DependentSignupRequest, bool>
    {
         
    }
}
