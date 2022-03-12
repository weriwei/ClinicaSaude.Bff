using System.Data;

namespace ClinicaSaude.Bff.Borders.Repositories
{
    public interface IDatabaseFactory
    {
        IDbConnection GetConnection();
    }
}