using System;
using System.Collections.Generic;
using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Borders.Shared;

namespace ClinicaSaude.Bff.Borders.UseCases
{
    public interface IGetAppointmentsUseCase : IUseCase<Guid, IEnumerable<AppointmentResponse>>
    {
         
    }
}
