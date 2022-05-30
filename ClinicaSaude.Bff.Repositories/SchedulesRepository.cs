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
    public class SchedulesRepository : ISchedulesRepository
    {
         private IRepositoryHelper _helper;

        public SchedulesRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByDoctorId(Guid doctorId)
        {
            using IDbConnection connection = _helper.GetConnection();

            var response = await connection.QueryAsync<Schedule>(DoctorRepositoryStatements.GET_SCHEDULES_AVAILABLE_BY_DOCTOR_ID, new { Id = doctorId });

            return response;
        }   
    }
}
