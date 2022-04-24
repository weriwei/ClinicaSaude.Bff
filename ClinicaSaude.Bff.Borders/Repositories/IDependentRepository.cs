using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Entities;

namespace ClinicaSaude.Bff.Borders.Repositories
{
    public interface IDependentRepository
    {
        Task<IEnumerable<Dependent>> GetDependentByUserId(Guid userId);

        Task<bool> CreateDependent(DependentSignupRequest dependentRequest);
    }
}
