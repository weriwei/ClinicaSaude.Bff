namespace ClinicaSaude.Bff.Shared.Constants
{
    public class ErrorMessages
    {
        public static readonly string UserConflict = "User already exists";
        public static readonly string ErrorMessageStatus404 = "Something went wrong. Data not found.";
        public static readonly string ErrorMessageStatus500 = "Something went wrong.";
        public static readonly string InvalidZipCode = "CEP ({PropertyValue}) inválido";
        public static readonly string InvalidLenght = "({PropertyName}) - Quantidade de caracteres inválida";
        public static readonly string EmptyValue = "Campo não pode ser vazio";
        public static readonly string InvalidEmail = "Email inválido";
        public static readonly string UserNotExist = "Email ou senha não correspondem à uma conta válida";
    }
}
