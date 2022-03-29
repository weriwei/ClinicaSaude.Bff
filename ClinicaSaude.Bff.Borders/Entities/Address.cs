namespace ClinicaSaude.Bff.Borders.Entities
{
    public record Address
    {
        public string User_Address_Street { get; init; } = string.Empty;
        public int User_Address_Number { get; init; }
        public string User_Address_City { get; init; } = string.Empty;
        public string User_Address_District { get; init; } = string.Empty;
        public string User_Address_Complement { get; init; } = string.Empty;
        public string User_Address_ZipCode { get; init; } = string.Empty;
    }
}
