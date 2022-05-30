using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Entities;

namespace ClinicaSaude.Bff.Borders.Repositories
{
    public interface IAppointmentsRepository
    {
        Task<bool> CreateAppointment(AppointmentRequest request);
        Task<IEnumerable<AppointmentResponse>> GetAppointmentsByPatientId(Guid patientId);
    }
}
