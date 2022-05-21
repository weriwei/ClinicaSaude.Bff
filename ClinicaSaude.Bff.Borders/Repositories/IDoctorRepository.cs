using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Entities;

namespace ClinicaSaude.Bff.Borders.Repositories
{
    public interface IDoctorRepository
    {
         Task<IEnumerable<Doctor>> GetDoctorBySpeciality(Guid specialityId);
    }
}
