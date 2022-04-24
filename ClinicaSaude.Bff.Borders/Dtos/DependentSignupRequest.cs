using System;
using ClinicaSaude.Bff.Borders.Enum;

namespace ClinicaSaude.Bff.Borders.Dtos
{
    public record DependentSignupRequest
    {
        public Guid UserId { get; init; }
        public string Name { get; init; } = string.Empty;
        public GenderType Gender { get; init; }
        public string Document { get; init; } = string.Empty;
        public DateTime Birthday { get; init; } = new DateTime();
    }
}
