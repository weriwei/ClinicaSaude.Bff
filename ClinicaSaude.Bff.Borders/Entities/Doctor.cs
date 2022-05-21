using System;

namespace ClinicaSaude.Bff.Borders.Entities
{
    public record Doctor
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Speciality_Name { get; init; } = string.Empty;
    }
}
