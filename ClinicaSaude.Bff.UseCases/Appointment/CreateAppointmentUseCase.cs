using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.Shared.Constants;

namespace ClinicaSaude.Bff.UseCases.Appointment
{
    public class CreateAppointmentUseCase : ICreateAppointmentUseCase
    {
        private readonly IAppointmentsRepository _appointmentsRepository;

        public CreateAppointmentUseCase(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        public async Task<UseCaseResponse<bool>> Execute(AppointmentRequest request)
        {
            try
            {
                var response = await _appointmentsRepository.CreateAppointment(request);

                if(response.Equals("true"))
                {
                    return UseCaseResponse<bool>.Success(true);
                }

                return UseCaseResponse<bool>.BadGateway(response);
            }
            catch
            {
                return UseCaseResponse<bool>.BadRequest(ErrorMessages.ErrorMessageStatus404);
            }
        }
    }
}
