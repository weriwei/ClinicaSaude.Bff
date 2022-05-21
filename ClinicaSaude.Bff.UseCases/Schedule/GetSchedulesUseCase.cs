using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.Shared.Constants;
using ScheduleEntity = ClinicaSaude.Bff.Borders.Entities.Schedule;

namespace ClinicaSaude.Bff.UseCases.Schedule
{
    public class GetSchedulesUseCase : IGetSchedulesUseCase
    {
        private readonly ISchedulesRepository _scheduleRepository;

        public GetSchedulesUseCase(ISchedulesRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<UseCaseResponse<IEnumerable<ScheduleEntity>>> Execute(Guid doctorId)
        {
            var response = await _scheduleRepository.GetSchedulesByDoctorId(doctorId);

            if(response is not null)
            {
                return UseCaseResponse<IEnumerable<ScheduleEntity>>.Success(response);
            }

            return UseCaseResponse<IEnumerable<ScheduleEntity>>.NotFound(ErrorMessages.ErrorMessageStatus404);
        }
    }
}
