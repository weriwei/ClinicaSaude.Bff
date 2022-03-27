using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;

namespace ClinicaSaude.Bff.UseCases.UserLogin
{
    public class UserLoginUseCase : IUserLoginUseCase
    {
        public async Task<UseCaseResponse<bool>> Execute(UserLoginRequest request)
        {
            await Task.Delay(30);
            return UseCaseResponse<bool>.Success(true);
        }
    }
}
