using System.Threading.Tasks;

namespace ClinicaSaude.Bff.Borders.Shared
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute(TRequest request);
    }
}
