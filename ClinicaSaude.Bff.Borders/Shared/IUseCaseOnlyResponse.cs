using System.Threading.Tasks;

namespace ClinicaSaude.Bff.Borders.Shared
{
    public interface IUseCaseOnlyResponse<TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute();
    }
}
