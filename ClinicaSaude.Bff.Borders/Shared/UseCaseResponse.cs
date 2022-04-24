using System.Collections.Generic;
using System.Linq;
using ClinicaSaude.Bff.Shared.Constants;

namespace ClinicaSaude.Bff.Borders.Shared
{
   public class UseCaseResponse<T>
    {
        public UseCaseResponseKind Status { get; private set; }
        public T? Result { get; private set; }
        public string? ResultId { get; private set; } 
        public string? ErrorMessage { get; private set; }
        public IEnumerable<ErrorMessage> Errors { get; private set; } = Enumerable.Empty<ErrorMessage>();

        protected UseCaseResponse(UseCaseResponseKind status)
        {
            Status = status;
        }

         protected UseCaseResponse(UseCaseResponseKind status, T result)
        {
            Status = status;
            Result = result;
        }

        protected UseCaseResponse(UseCaseResponseKind status, T result, string resultId)
        {
            Status = status;
            Result = result;
            ResultId = resultId;
        }

         protected UseCaseResponse(UseCaseResponseKind status, string? errorMessage = null, IEnumerable<ErrorMessage>? errors = null)
        {
            ErrorMessage = errorMessage;
            Status = status;
            Errors = errors ?? Enumerable.Empty<ErrorMessage>();
        }

        public static UseCaseResponse<T> Persisted(T result, string resultId) => new(UseCaseResponseKind.DataPersisted, result, resultId);
        public static UseCaseResponse<T> Success(T result) => new(UseCaseResponseKind.Success, result);
        public static UseCaseResponse<T> Success() => new(UseCaseResponseKind.Success);
        public static UseCaseResponse<T> Accepted(T result) => new(UseCaseResponseKind.DataAccepted, result);
        public static UseCaseResponse<T> Accepted(T result, string resultId) => new(UseCaseResponseKind.DataAccepted, result, resultId);
        public static UseCaseResponse<T> Unavailable(T result) => new(UseCaseResponseKind.Unavailable, result) { ErrorMessage = "Service Unavailable" };
        public static UseCaseResponse<T> NotFound() => NotFound(new ErrorMessage[] { new ErrorMessage(ErrorCodes.ValidationError, ErrorMessages.ErrorMessageStatus404) });
        public static UseCaseResponse<T> NotFound(string message) => new(UseCaseResponseKind.NotFound, message);
        public static UseCaseResponse<T> NotFound(IEnumerable<ErrorMessage> errors) => new(UseCaseResponseKind.NotFound, "Data not found", errors);
        public static UseCaseResponse<T> BadRequest(IEnumerable<ErrorMessage> errors) => new(UseCaseResponseKind.BadRequest, "Bad Request", errors);
        public static UseCaseResponse<T> BadRequest(string message) => new(UseCaseResponseKind.BadRequest, message);
        public static UseCaseResponse<T> BadGateway() => BadGateway(new ErrorMessage[] { new ErrorMessage(ErrorCodes.BadGateway, ErrorMessages.ErrorMessageStatus500) });
        public static UseCaseResponse<T> BadGateway(IEnumerable<ErrorMessage> errors) => new(UseCaseResponseKind.BadGateway, "Bad Gateway", errors);
        public static UseCaseResponse<T> InternalServerError(IEnumerable<ErrorMessage> errors) => new(UseCaseResponseKind.InternalServerError, "Internal Server Error", errors);
        public static UseCaseResponse<T> InternalServerError() => InternalServerError(new ErrorMessage[] { new ErrorMessage(ErrorCodes.InternalServerError, ErrorMessages.ErrorMessageStatus500) });
    }
}
