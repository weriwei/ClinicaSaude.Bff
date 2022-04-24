using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.Shared.Constants;

namespace ClinicaSaude.Bff.UseCases.CreateDependent
{
    public class CreateDependentUseCase : ICreateDependentUseCase
    {
        private readonly IDependentRepository _dependetRepository;

        public CreateDependentUseCase(IDependentRepository dependetRepository)
        {
            _dependetRepository = dependetRepository;
        }

        public async Task<UseCaseResponse<bool>> Execute(DependentSignupRequest request)
        {
            var response = await _dependetRepository.CreateDependent(request);

            if(response)
            {
                return UseCaseResponse<bool>.Persisted(response, request.UserId.ToString());
            }

            return UseCaseResponse<bool>.BadRequest(ErrorMessages.UserConflict);
        }
    }
}
