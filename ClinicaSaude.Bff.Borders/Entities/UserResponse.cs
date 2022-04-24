using System;
using ClinicaSaude.Bff.Borders.Enum;

namespace ClinicaSaude.Bff.Borders.Entities
{
    public record UserResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public GenderType Gender { get; init; }
        public string Document { get; init; } = string.Empty;
        public Address Address { get; init; } = new Address();
        public DateTime Birthday { get; init; } = new DateTime();
    }
}
