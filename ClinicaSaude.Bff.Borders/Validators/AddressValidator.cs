using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Shared.Constants;
using FluentValidation;

namespace ClinicaSaude.Bff.Borders.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator(ZipCodeValidator zipCodeValidator)
        {
            RuleFor(request => request).NotNull().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.User_Address_City).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.User_Address_Number).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.User_Address_District).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.User_Address_Complement).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.User_Address_Street).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.User_Address_ZipCode).SetValidator(zipCodeValidator!);
        }
    }
}
