using System;

namespace ClinicaSaude.Bff.Borders.Entities
{
    public record Schedule
    {
        public Guid Id { get; init; }
        public Guid Id_Doctor { get; init; }
        public DateTime Date { get; init; }
    }
}
