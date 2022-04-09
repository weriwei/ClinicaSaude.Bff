using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.Borders.Validators;
using ClinicaSaude.Bff.Shared.Constants;
using ClinicaSaude.Bff.Shared.Extensions;
using FluentValidation;

namespace ClinicaSaude.Bff.UseCases.UserLogin
{
    public class UserLoginUseCase : IUserLoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserLoginRequestValidator _userLoginRequestValidator;

        public UserLoginUseCase(IUserRepository userRepository, UserLoginRequestValidator userLoginRequestValidator)
        {
            _userRepository = userRepository;
            _userLoginRequestValidator = userLoginRequestValidator;
        }

        public async Task<UseCaseResponse<bool?>> Execute(UserLoginRequest request)
        {
            try
            {
                _userLoginRequestValidator.ValidateAndThrow(request);
                
                var response = await _userRepository.GetUserByEmail(request.Email);

                if(response is not null && response.User_Password == request.Password)
                    return UseCaseResponse<bool?>.Success(true);

                return UseCaseResponse<bool?>.NotFound(ErrorMessages.UserNotExist);
            }
            catch (ValidationException ex)
            {
                return UseCaseResponse<bool?>.BadRequest(ex.ToErrorsMessage());
            }
           
        }
    }
}
