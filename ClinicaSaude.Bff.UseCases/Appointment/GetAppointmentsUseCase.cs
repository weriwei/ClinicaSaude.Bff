using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.Shared.Constants;

namespace ClinicaSaude.Bff.UseCases.Appointment
{
    public class GetAppointmentsUseCase : IGetAppointmentsUseCase
    {
        private readonly IAppointmentsRepository _appointmentsRepository;

        public GetAppointmentsUseCase(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        public async Task<UseCaseResponse<IEnumerable<AppointmentResponse>>> Execute(Guid patientId)
        {
            var response = await _appointmentsRepository.GetAppointmentsByPatientId(patientId);

            if(response is not null)
            {
                return UseCaseResponse<IEnumerable<AppointmentResponse>>.Success(response);
            }

            return UseCaseResponse<IEnumerable<AppointmentResponse>>.NotFound(ErrorMessages.ErrorMessageStatus404);
        }
    }
}
