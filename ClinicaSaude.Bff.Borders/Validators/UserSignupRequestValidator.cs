using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Shared.Constants;
using FluentValidation;

namespace ClinicaSaude.Bff.Borders.Validators
{
    public class UserSignupRequestValidator : AbstractValidator<UserSignupRequest>
    {
        public UserSignupRequestValidator(AddressValidator addressValidator)
        {
            RuleFor(request => request.Name).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.DocumentNumber).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.DocumentNumber).Must(documentNumber => documentNumber.Length == Constants.CPF_LENGTH).WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Email).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Password).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Gender).IsInEnum().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Address).SetValidator(addressValidator!);
        }
        
    }
}
