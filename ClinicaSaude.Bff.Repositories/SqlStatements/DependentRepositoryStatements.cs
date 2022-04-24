namespace ClinicaSaude.Bff.Repositories.SqlStatements
{
    public static class DependentRepositoryStatements
    {
        public const string INSERT_DEPENDENT = @"
            INSERT INTO dependente 
            (
                nome,
                documento,
                data_nascimento,
                genero,
                id_responsavel
            )
            VALUES (@Name, @Document, @Birthday, @Gender, @UserId)";

        public const string SELECT_BY_USER_ID = @"
            SELECT * FROM dependente WHERE id_responsavel = @UserId";
    }
}
