using System.Collections.Generic;
using System.Linq;
using ClinicaSaude.Bff.Borders.Shared;
using FluentValidation;

namespace ClinicaSaude.Bff.Shared.Extensions
{
    public static class ValidationExceptionExtensions
    {
        public static IEnumerable<ErrorMessage> ToErrorsMessage(this ValidationException exception)
        {
            return exception.Errors.Select(error => new ErrorMessage(error.ErrorCode, error.ErrorMessage));
        }
    }
}
