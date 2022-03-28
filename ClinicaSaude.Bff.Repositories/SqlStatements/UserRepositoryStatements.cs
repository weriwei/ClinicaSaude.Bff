namespace ClinicaSaude.Bff.Repositories.SqlStatements
{
    public static class UserRepositoryStatements
    {
        public const string INSERT_USER = @"
            INSERT INTO users 
            (
                user_name, 
                user_gender, 
                user_document, 
                user_email,
                user_address_street,
                user_address_number,
                user_address_city,
                user_address_district,
                user_address_complement,
                user_address_zipcode
                )
            VALUES (@Name, @Gender, @DocumentNumber, @Email,@Street, @Number, @City,
                @District, @Complement, @ZipCode)";

        public const string SELECT_BY_EMAIL = @"
        SELECT * FROM users WHERE user_email = @Email";
    }
}
