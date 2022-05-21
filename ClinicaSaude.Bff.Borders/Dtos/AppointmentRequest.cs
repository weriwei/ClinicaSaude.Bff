using System;
using ClinicaSaude.Bff.Borders.Enum;

namespace ClinicaSaude.Bff.Borders.Dtos
{
    public record AppointmentRequest
    {
        public Guid Id_Schedule { get; init; }
        public Guid Id_Patient { get; init; }
        public AppointmentStatusType Status { get; init; }
    }
}
