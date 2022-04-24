using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Entities;
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

        public async Task<UseCaseResponse<UserResponse?>> Execute(UserLoginRequest request)
        {
            try
            {
                _userLoginRequestValidator.ValidateAndThrow(request);
                
                var response = await _userRepository.GetUserByEmail(request.Email);

                if(response is not null && response.User_Password == request.Password)
                {
                    var userResponse = new UserResponse()
                    {
                        Id = response.User_Id,
                        Name = response.User_Name,
                        Gender = response.User_Gender,
                        Document = response.User_Document,
                        Address = new Address()
                        {
                            User_Address_Street = response.User_Address_Street,
                            User_Address_City = response.User_Address_City,
                            User_Address_Number = response.User_Address_Number,
                            User_Address_Complement = response.User_Address_Complement,
                            User_Address_ZipCode = response.User_Address_ZipCode,
                            User_Address_District = response.User_Address_District
                        },
                        Birthday = response.User_Birthday
                    };

                    return UseCaseResponse<UserResponse?>.Success(userResponse);
                }

                return UseCaseResponse<UserResponse?>.NotFound(ErrorMessages.UserNotExist);
            }
            catch (ValidationException ex)
            {
                return UseCaseResponse<UserResponse?>.BadRequest(ex.ToErrorsMessage());
            }
           
        }
    }
}
