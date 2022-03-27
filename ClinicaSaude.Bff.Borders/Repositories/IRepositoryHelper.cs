using System.Data;

namespace ClinicaSaude.Bff.Borders.Repositories
{
    public interface IRepositoryHelper
    {
        public IDbConnection GetConnection();
    }
}
