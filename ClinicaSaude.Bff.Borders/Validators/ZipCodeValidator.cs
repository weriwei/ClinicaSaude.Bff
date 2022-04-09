using ClinicaSaude.Bff.Shared.Constants;
using FluentValidation;

namespace ClinicaSaude.Bff.Borders.Validators
{
    public class ZipCodeValidator : AbstractValidator<string>
    {
        public ZipCodeValidator()
        {
            When(number => number?.Length > 0, () =>
            {
                RuleFor(number => number).Must(number => number.Length == Constants.ZIP_CODE_LENGTH).WithMessage(ErrorMessages.InvalidLenght).WithErrorCode(ErrorCodes.InvalidValue)
                .Must(number =>
                {
                    if (int.TryParse(number, out int value))
                    {
                        return true;
                    }

                    return false;
                }).WithMessage(ErrorMessages.InvalidZipCode).WithErrorCode(ErrorCodes.InvalidValue);
            });
            RuleFor(number => number).NotEmpty().WithMessage(ErrorMessages.EmptyValue).WithErrorCode(ErrorCodes.InvalidValue);
        }
        
    }
}
