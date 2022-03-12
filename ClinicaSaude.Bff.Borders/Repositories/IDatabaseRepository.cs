using System.Threading;

namespace ClinicaSaude.Bff.Borders.Repositories
{
    public interface IDatabaseRepository
    {
        Task<bool> CheckHealth();
    }
}
