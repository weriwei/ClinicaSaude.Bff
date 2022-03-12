using System.Data;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;using Microsoft.Data.SqlClient;
namespace ClinicaSaude.Bff.Repositories
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly ApplicationConfig config;

        public DatabaseFactory(ApplicationConfig config)
        {
            this.config = config;
        }

        public IDbConnection GetConnection()
        {            var factory = SqlClientFactory.Instance;            var connection = factory.CreateConnection();
            connection.ConnectionString = config.ConnectionStrings.DefaultConnection;

            return connection;
        }
    }
}