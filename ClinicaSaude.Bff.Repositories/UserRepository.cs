using System.Data;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Entities;
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

        public async Task<bool> CreateUser(UserSignupRequest userRequest)
        {
            try
            {
                using IDbConnection connection = _helper.GetConnection();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Name", userRequest.Name, DbType.String);
                parameters.Add("@Password", userRequest.Password, DbType.String);
                parameters.Add("@DocumentNumber", userRequest.DocumentNumber, DbType.String);
                parameters.Add("@Email", userRequest.Email, DbType.String);
                parameters.Add("@Birthday", userRequest.Birthday, DbType.DateTime);
                parameters.Add("@Street", userRequest.Address.User_Address_Street, DbType.String);
                parameters.Add("@Number", userRequest.Address.User_Address_Number, DbType.Int16);
                parameters.Add("@City", userRequest.Address.User_Address_City, DbType.String);
                parameters.Add("@District", userRequest.Address.User_Address_District, DbType.String);
                parameters.Add("@Complement", userRequest.Address.User_Address_Complement, DbType.String);
                parameters.Add("@ZipCode", userRequest.Address.User_Address_ZipCode, DbType.String);
                parameters.Add("@Gender", userRequest.Gender, DbType.Int16);

                await connection.QueryAsync<bool>(UserRepositoryStatements.INSERT_USER, parameters);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<User?> GetUserByEmail(string email)
        {
            using IDbConnection connection = _helper.GetConnection();

            var response = await connection.QueryFirstOrDefaultAsync<User>(UserRepositoryStatements.SELECT_BY_EMAIL, new {Email = email});

            return response;
        }
    }
}
