namespace ClinicaSaude.Bff.Shared.Constants
{
    public static class ErrorCodes
    {
        private static readonly string prefix = "20";
        public static string UnhandledError => $"{prefix}.00";
        public static string NotFound => $"{prefix}.01";
        public static string BadGateway => $"{prefix}.02";
        public static string InvalidValue => $"{prefix}.03";
        
    }
}
