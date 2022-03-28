using System.Data;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Repositories.SqlStatements;
using Dapper;

namespace ClinicaSaude.Bff.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IRepositoryHelper _helper;

        public UserRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public async Task CreateUser(UserSignupRequest userRequest)
        {
            using IDbConnection connection = _helper.GetConnection();

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@Name", userRequest.Name, DbType.String);
            parameters.Add("@DocumentNumber", userRequest.DocumentNumber, DbType.String);
            parameters.Add("@Email", userRequest.Email, DbType.String);
            parameters.Add("@Street", userRequest.Address.Street, DbType.String);
            parameters.Add("@Number", userRequest.Address.Number, DbType.Int16);
            parameters.Add("@City", userRequest.Address.City, DbType.String);
            parameters.Add("@District", userRequest.Address.District, DbType.String);
            parameters.Add("@Complement", userRequest.Address.Complement, DbType.String);
            parameters.Add("@ZipCode", userRequest.Address.ZipCode, DbType.String);
            parameters.Add("@Gender", userRequest.Gender, DbType.Int16);

            await connection.QueryAsync<bool>(UserRepositoryStatements.INSERT_USER, parameters);
        }


        public async Task<UserResponse> GetUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}
