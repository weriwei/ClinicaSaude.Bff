using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;

namespace ClinicaSaude.Bff.UseCases.UserLogin
{
    public class UserLoginUseCase : IUserLoginUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserLoginUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UseCaseResponse<bool>> Execute(UserLoginRequest request)
        {
            //[WIP] Create crypto to save hash from password into db
            var response = await _userRepository.GetUserByEmail(request.Email);

            if(response is not null && response.User_Password == request.Password)
                return UseCaseResponse<bool>.Success(true);

            return UseCaseResponse<bool>.Success(false);
        }
    }
}
