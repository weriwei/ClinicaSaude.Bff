using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;

namespace ClinicaSaude.Bff.UseCases.UserSignup
{
    public class UserSignupUseCase : IUserSignupUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserSignupUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UseCaseResponse<bool?>> Execute(UserSignupRequest request)
        {
            //[WIP] Create validator to UserSignupRequest

            var response = await _userRepository.CreateUser(request);

            if(!response)
                return UseCaseResponse<bool?>.BadGateway();

            return UseCaseResponse<bool?>.Success(true);
        }
    }
}
