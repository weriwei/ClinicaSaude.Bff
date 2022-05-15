using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Repositories.SqlStatements;
using Dapper;

namespace ClinicaSaude.Bff.Repositories
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private IRepositoryHelper _helper;

        public SpecialityRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public async Task<IEnumerable<Speciality>> GetSpecialitys()
        {
            using IDbConnection connection = _helper.GetConnection();

            var response = await connection.QueryAsync<Speciality>(SpecialityRepositoryStatements.GET_SPECIALITYS);

            return response;
        }
    }
}
