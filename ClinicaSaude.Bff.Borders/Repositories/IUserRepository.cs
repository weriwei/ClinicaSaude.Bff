using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;


namespace ClinicaSaude.Bff.Borders.Repositories
{
    public interface IUserRepository
    {
        Task<UserResponse> GetUserByEmail(string email);
        Task CreateUser(UserSignupRequest userRequest);
    }
}
