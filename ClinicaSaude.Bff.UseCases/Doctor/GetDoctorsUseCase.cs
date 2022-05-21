using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Repositories;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using ClinicaSaude.Bff.Shared.Constants;
using DoctorEntity = ClinicaSaude.Bff.Borders.Entities.Doctor;

namespace ClinicaSaude.Bff.UseCases.Doctor
{
    public class GetDoctorsUseCase : IGetDoctorsUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorsUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<UseCaseResponse<IEnumerable<DoctorEntity>>> Execute(Guid request)
        {
            var response = await _doctorRepository.GetDoctorBySpeciality(request);

            if(response is not null)
            {
                return UseCaseResponse<IEnumerable<DoctorEntity>>.Success(response);
            }

            return UseCaseResponse<IEnumerable<DoctorEntity>>.NotFound(ErrorMessages.ErrorMessageStatus404);
        }
    }
}
