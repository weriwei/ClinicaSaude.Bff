using System;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.Borders.Validators;
using ClinicaSaude.Bff.Shared.Constants;
using ClinicaSaude.Bff.Shared.Extensions;
using FluentValidation;

namespace ClinicaSaude.Bff.UseCases.UserSignup
{
    public class UserSignupUseCase : IUserSignupUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserSignupRequestValidator _userSignupRequestValidator;

        public UserSignupUseCase(IUserRepository userRepository, UserSignupRequestValidator userSignupRequestValidator)
        {
            _userRepository = userRepository;
            _userSignupRequestValidator = userSignupRequestValidator;
        }

        public async Task<UseCaseResponse<bool?>> Execute(UserSignupRequest request)
        {
            try
            {
                _userSignupRequestValidator.ValidateAndThrow(request);

                var response = await _userRepository.CreateUser(request);

                if (response)
                {
                    return UseCaseResponse<bool?>.Persisted(response, Guid.NewGuid().ToString());
                }

                return UseCaseResponse<bool?>.BadRequest(ErrorMessages.UserConflict);
            }
            catch (ValidationException ex)
            {
                return UseCaseResponse<bool?>.BadRequest(ex.ToErrorsMessage());
            }

        }
    }
}
