using System;
using ClinicaSaude.Bff.Borders.Enum;

namespace ClinicaSaude.Bff.Borders.Entities
{
    public record User
    {   
        public Guid User_Id { get; init; }
        public string User_Name { get; init; } = string.Empty;
        public string User_Password { get; init; } = string.Empty;
        public string User_Email { get; init; } = string.Empty;
        public GenderType User_Gender { get; init; }
        public string User_Document { get; init; } = string.Empty;
        public string User_Address_Street { get; init; } = string.Empty;
        public int User_Address_Number { get; init; }
        public string User_Address_City { get; init; } = string.Empty;
        public string User_Address_District { get; init; } = string.Empty;
        public string User_Address_Complement { get; init; } = string.Empty;
        public string User_Address_ZipCode { get; init; } = string.Empty;
        public DateTime User_Birthday { get; init; } = new DateTime();
    }
}
