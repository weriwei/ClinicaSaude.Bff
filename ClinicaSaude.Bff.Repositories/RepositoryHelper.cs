using System;
using System.Data;
using ClinicaSaude.Bff.Borders.Repositories;
using Npgsql;

namespace ClinicaSaude.Bff.Repositories
{
    public class RepositoryHelper : IRepositoryHelper
    {
        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
        }
    }
}
