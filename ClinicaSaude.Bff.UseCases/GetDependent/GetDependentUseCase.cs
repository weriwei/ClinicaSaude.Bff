using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.Shared.Constants;

namespace ClinicaSaude.Bff.UseCases.GetDependent
{
    public class GetDependentUseCase : IGetDependentUseCase
    {
        private readonly IDependentRepository _dependetRepository;

        public GetDependentUseCase(IDependentRepository dependetRepository)
        {
            _dependetRepository = dependetRepository;
        }

        public async Task<UseCaseResponse<IEnumerable<Dependent>>> Execute(Guid request)
        {
            var response = await _dependetRepository.GetDependentByUserId(request);

            if(response is not null)
            {
                return UseCaseResponse<IEnumerable<Dependent>>.Success(response);
            }

            return UseCaseResponse<IEnumerable<Dependent>>.NotFound(ErrorMessages.ErrorMessageStatus404);
        }
    }
}
