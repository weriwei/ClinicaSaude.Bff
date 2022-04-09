using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Entities;

namespace ClinicaSaude.Bff.Borders.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email);
        Task<bool> CreateUser(UserSignupRequest userRequest);
    }
}
