using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Enum;

namespace ClinicaSaude.Bff.Borders.Entities
{
    public record User
    {
        public string Name { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public GenderType Gender { get; init; }
        public string DocumentNumber { get; init; } = string.Empty;
        public Address Address { get; init; }
        
    }
}
