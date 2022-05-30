using System;
using ClinicaSaude.Bff.Borders.Enum;

namespace ClinicaSaude.Bff.Borders.Entities
{
    public record AppointmentResponse
    {
        public string Name { get; init; } = string.Empty;
        public string Speciality { get; init; } = string.Empty;
        public DateTime Date { get; init; }
        public AppointmentStatusType Status { get; init; }
    }
}
