using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Repositories.SqlStatements;
using Dapper;

namespace ClinicaSaude.Bff.Repositories
{
    public class DependentRepository : IDependentRepository
    {
        private IRepositoryHelper _helper;

        public DependentRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public async Task<bool> CreateDependent(DependentSignupRequest dependentRequest)
        {
            try
            {
                using IDbConnection connection = _helper.GetConnection();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Name", dependentRequest.Name, DbType.String);
                parameters.Add("@Document", dependentRequest.Document, DbType.String);
                parameters.Add("@Birthday", dependentRequest.Birthday, DbType.DateTime);
                parameters.Add("@Gender", dependentRequest.Gender, DbType.Int16);
                parameters.Add("@UserId", dependentRequest.UserId, DbType.Guid);

                await connection.QueryAsync<bool>(DependentRepositoryStatements.INSERT_DEPENDENT, parameters);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Dependent>> GetDependentByUserId(Guid userId)
        {
            using IDbConnection connection = _helper.GetConnection();

            var response = await connection.QueryAsync<Dependent>(DependentRepositoryStatements.SELECT_BY_USER_ID, new { UserId = userId });

            return response;
        }
    }
}
