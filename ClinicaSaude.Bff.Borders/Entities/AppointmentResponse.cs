using System;
using ClinicaSaude.Bff.Borders.Enum;

namespace ClinicaSaude.Bff.Borders.Entities
{
    public record AppointmentResponse
    {
        public Guid Id_Schedule { get; init; }
        public Guid Id_Patient { get; init; }
        public DateTime Date { get; init; }
        public AppointmentStatusType Status { get; init; }
    }
}
