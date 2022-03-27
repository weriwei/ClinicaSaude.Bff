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

        public async Task<bool> CreateUser(UserSignupRequest userRequest)
        {
            using IDbConnection connection = _helper.GetConnection();

            return await connection.QueryFirstAsync<bool>(UserRepositoryStatements.INSERT_USER);
        }


        public async Task<UserResponse> GetUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}
