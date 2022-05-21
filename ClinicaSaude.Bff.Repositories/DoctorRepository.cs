using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Repositories.SqlStatements;
using Dapper;

namespace ClinicaSaude.Bff.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private IRepositoryHelper _helper;

        public DoctorRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorBySpeciality(Guid specialityId)
        {
            using IDbConnection connection = _helper.GetConnection();

            var response = await connection.QueryAsync<Doctor>(DoctorRepositoryStatements.GET_DOCTOR_BY_SPECIALITY_ID, new { Id = specialityId});

            return response;
        }
    }
}
