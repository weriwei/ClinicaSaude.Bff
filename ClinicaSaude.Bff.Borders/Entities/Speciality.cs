using System;

namespace ClinicaSaude.Bff.Borders.Entities
{
    public record Speciality
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
