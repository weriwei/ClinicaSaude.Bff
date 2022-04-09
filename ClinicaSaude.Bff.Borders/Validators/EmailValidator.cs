using System.Text.RegularExpressions;
using ClinicaSaude.Bff.Shared.Constants;
using FluentValidation;

namespace ClinicaSaude.Bff.Borders.Validators
{
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(request => request)
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
