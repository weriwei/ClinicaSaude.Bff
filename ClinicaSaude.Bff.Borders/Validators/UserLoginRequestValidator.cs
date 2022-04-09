using System.Text.RegularExpressions;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Shared.Constants;
using FluentValidation;

namespace ClinicaSaude.Bff.Borders.Validators
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(request => request).NotNull().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Email).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Password).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Password.Length).InclusiveBetween(Constants.MIN_PASSWORD_LENGTH, Constants.MAX_PASSWORD_LENGTH ).WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithErrorCode(ErrorCodes.InvalidValue).WithMessage(ErrorMessages.EmptyValue)
                .EmailAddress().WithErrorCode(ErrorCodes.InvalidValue).WithMessage(ErrorMessages.InvalidEmail)
                .Must(IsValidEmail).WithErrorCode(ErrorCodes.InvalidValue).WithMessage(ErrorMessages.InvalidEmail);
        }

        private static bool IsValidEmail(string email)
        {
            const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, pattern);
        }
    }
}
