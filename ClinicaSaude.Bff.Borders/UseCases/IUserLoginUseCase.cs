using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Borders.Shared;

namespace ClinicaSaude.Bff.Borders.UseCases
{
    public interface IUserLoginUseCase : IUseCase<UserLoginRequest, UserResponse?>
    {
         
    }
}
