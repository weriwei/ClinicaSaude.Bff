using System;
using System.Collections.Generic;
using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Borders.Shared;

namespace ClinicaSaude.Bff.Borders.UseCases
{
    public interface IGetDoctorsUseCase :  IUseCase<Guid, IEnumerable<Doctor>>
    {
         
    }
}
