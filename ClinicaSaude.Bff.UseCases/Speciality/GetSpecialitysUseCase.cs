using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.Shared.Constants;
using SpecialityEntity = ClinicaSaude.Bff.Borders.Entities.Speciality;

namespace ClinicaSaude.Bff.UseCases.Speciality
{
    public class GetSpecialitysUseCase : IGetSpecialitysUseCase
    {
        private readonly ISpecialityRepository _specialityRepository;

        public GetSpecialitysUseCase(ISpecialityRepository specialityRepository)
        {
            _specialityRepository = specialityRepository;
        }

        public async Task<UseCaseResponse<IEnumerable<SpecialityEntity>>> Execute()
        {
            var response = await _specialityRepository.GetSpecialitys();

            if(response is not null)
            {
                return UseCaseResponse<IEnumerable<SpecialityEntity>>.Success(response);
            }

            return UseCaseResponse<IEnumerable<SpecialityEntity>>.NotFound(ErrorMessages.ErrorMessageStatus404);
        }
    }
}
