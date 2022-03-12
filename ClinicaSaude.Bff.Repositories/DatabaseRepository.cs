using System.Threading.Tasks;
using Dapper;
using ClinicaSaude.Bff.Borders.Repositories;

namespace ClinicaSaude.Bff.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly IDatabaseFactory databaseFactory;

        public DatabaseRepository(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        public async Task<bool> CheckHealth()
        {
            const string query = "SELECT 1";
            using var connection = databaseFactory.GetConnection();

            try
            {
                return await connection.QueryFirstOrDefaultAsync<bool>(query);
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}