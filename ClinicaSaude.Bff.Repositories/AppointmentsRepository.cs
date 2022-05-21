using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Repositories.SqlStatements;
using Dapper;
using Npgsql;

namespace ClinicaSaude.Bff.Repositories
{
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private IRepositoryHelper _helper;

        public AppointmentsRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public async Task<string> CreateAppointment(AppointmentRequest request)
        {
            try
            {
                using IDbConnection connection = _helper.GetConnection();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id_Schedule", request.Id_Schedule, DbType.Guid);
                parameters.Add("@Id_Patient", request.Id_Patient, DbType.Guid);
                parameters.Add("@Status", request.Status, DbType.Int16);

                await connection.QueryAsync<bool>(AppointmentsRepositoryStatements.INSERT_APPOINTMENT, parameters);

                return true.ToString();
            }
            catch(PostgresException ex)
            {
                return ex.MessageText;
            }
        }

        public async Task<IEnumerable<AppointmentResponse>> GetAppointmentsByPatientId(Guid patientId)
        {
            using IDbConnection connection = _helper.GetConnection();

            var response = await connection.QueryAsync<AppointmentResponse>(AppointmentsRepositoryStatements.GET_APPOINTMENTS_BY_PATIENT_ID, new { Id_Patient = patientId });

            return response;
        }
    }
}
