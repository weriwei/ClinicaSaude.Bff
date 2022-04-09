using System;
using ClinicaSaude.Bff.Borders.Enum;

namespace ClinicaSaude.Bff.Borders.Entities
{
    public record User
    {
        public string User_Name { get; init; } = string.Empty;
        public string User_Password { get; init; } = string.Empty;
        public string User_Email { get; init; } = string.Empty;
        public GenderType User_Gender { get; init; }
        public string User_Document { get; init; } = string.Empty;
        public Address User_Address { get; init; } = new Address();
        public DateTime User_Birthday { get; init; } = new DateTime();
    }
}
