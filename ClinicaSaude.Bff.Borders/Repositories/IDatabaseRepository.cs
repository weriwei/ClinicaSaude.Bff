using System.Threading.Tasks;

namespace ClinicaSaude.Bff.Borders.Repositories
{
    public interface IDatabaseRepository
    {
        Task<bool> CheckHealth();
    }
}
