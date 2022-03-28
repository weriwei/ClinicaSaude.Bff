namespace ClinicaSaude.Bff.Borders.Dtos
{
    public record Address
    {
        public string Street { get; init; } = string.Empty;
        public int Number { get; init; }
        public string City { get; init; } = string.Empty;
        public string District { get; init; } = string.Empty;
        public string Complement { get; init; } = string.Empty;
        public string ZipCode { get; init; } = string.Empty;
    }
}
