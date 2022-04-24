using System;
using ClinicaSaude.Bff.Borders.Enum;

namespace ClinicaSaude.Bff.Borders.Entities
{
    public record Dependent
    {
        public Guid Id_Responsavel { get; init; }
        public string Nome { get; init; } = string.Empty;
        public GenderType Genero { get; init; }
        public string Documento { get; init; } = string.Empty;
        public DateTime Data_Nascimento { get; init; } = new DateTime();
    }
}
