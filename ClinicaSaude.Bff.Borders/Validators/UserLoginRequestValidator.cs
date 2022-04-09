using System.Text.RegularExpressions;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Shared.Constants;
using FluentValidation;

namespace ClinicaSaude.Bff.Borders.Validators
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator(EmailValidator emailValidator)
        {
            RuleFor(request => request).NotNull().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Email).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Password).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Password.Length).InclusiveBetween(Constants.MIN_PASSWORD_LENGTH, Constants.MAX_PASSWORD_LENGTH ).WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Email).SetValidator(emailValidator!);
        }
    }
}
