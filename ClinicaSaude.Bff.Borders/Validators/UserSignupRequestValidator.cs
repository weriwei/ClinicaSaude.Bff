using System;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Shared.Constants;
using FluentValidation;

namespace ClinicaSaude.Bff.Borders.Validators
{
    public class UserSignupRequestValidator : AbstractValidator<UserSignupRequest>
    {
        private static DateTime MinDatePeriodStart => new DateTime(1900,01,01);
        private static DateTime MaxDatePeriodStart => DateTime.Now.Date;
        public UserSignupRequestValidator(AddressValidator addressValidator, EmailValidator emailValidator)
        {
            RuleFor(request => request.Name).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Password).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Password.Length).InclusiveBetween(Constants.MIN_PASSWORD_LENGTH, Constants.MAX_PASSWORD_LENGTH ).WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.DocumentNumber).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.DocumentNumber).Must(documentNumber => documentNumber.Length == Constants.CPF_LENGTH).WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request).Must(request => request.Birthday.Date >= MinDatePeriodStart).WithErrorCode(ErrorCodes.InvalidValue).WithMessage(ErrorMessages.InvalideDate);
            RuleFor(request => request).Must(request => request.Birthday.Date <= MaxDatePeriodStart).WithErrorCode(ErrorCodes.InvalidValue).WithMessage(ErrorMessages.InvalideDate);;
            RuleFor(request => request.Email).NotEmpty().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Email).SetValidator(emailValidator!);
            RuleFor(request => request.Gender).IsInEnum().WithErrorCode(ErrorCodes.InvalidValue);
            RuleFor(request => request.Address).SetValidator(addressValidator!);
        }
    }
}
