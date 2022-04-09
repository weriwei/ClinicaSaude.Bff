using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using ClinicaSaude.Bff.Borders.Shared;

namespace ClinicaSaude.Bff.Api.Models
{
   public interface IActionResultConverter
    {
        IActionResult Convert<T>(UseCaseResponse<T> response, bool noContentIfSuccess = false);
    }

    public class ActionResultConverter : IActionResultConverter
    {
        public IActionResult Convert<T>(UseCaseResponse<T>? response, bool noContentIfSuccess = false)
        {
            if (response == null)
                return BuildError(new[] { new ErrorMessage("000", "ActionResultConverter Error") }, UseCaseResponseKind.InternalServerError);

            if (response.ErrorMessage is null)
            {
                if (noContentIfSuccess)
                {
                    return new NoContentResult();
                }
                else
                {
                    return BuildSuccessResult(response.Result, response.Status, response.ResultId);
                }
            }
            else if (response.Result != null)
            {
                return BuildError(response.Result, response.Status);
            }
            else
            {
                var hasErrors = response.Errors == null || !response.Errors.Any();
                var errorResult = hasErrors
                    ? new[] { new ErrorMessage("000", response.ErrorMessage ?? "Unknown error") }
                    : response.Errors;

                return BuildError(errorResult!, response.Status);
            }
        }

        private static IActionResult BuildSuccessResult(object? data, UseCaseResponseKind status, string? id)
        {
            return status switch
            {
                UseCaseResponseKind.DataPersisted => new CreatedResult(id!, data),
                _ => new OkObjectResult(data)
            };
        }

        private static ObjectResult BuildError(object data, UseCaseResponseKind status)
        {
            var httpStatus = GetErrorHttpStatusCode(status);

            return new ObjectResult(data)
            {
                StatusCode = (int)httpStatus
            };
        }

        private static HttpStatusCode GetErrorHttpStatusCode(UseCaseResponseKind status)
        {
            return status switch
            {
                UseCaseResponseKind.RequestValidationError or UseCaseResponseKind.ForeignKeyViolationError or UseCaseResponseKind.BadRequest => HttpStatusCode.BadRequest,
                UseCaseResponseKind.Unauthorized => HttpStatusCode.Unauthorized,
                UseCaseResponseKind.Forbidden => HttpStatusCode.Forbidden,
                UseCaseResponseKind.NotFound => HttpStatusCode.NotFound,
                UseCaseResponseKind.UniqueViolationError => HttpStatusCode.Conflict,
                UseCaseResponseKind.Unavailable => HttpStatusCode.ServiceUnavailable,
                UseCaseResponseKind.BadGateway => HttpStatusCode.BadGateway,
                UseCaseResponseKind.UnprocessableEntity => HttpStatusCode.UnprocessableEntity,
                _ => HttpStatusCode.InternalServerError,
            };
        }
    }
}
