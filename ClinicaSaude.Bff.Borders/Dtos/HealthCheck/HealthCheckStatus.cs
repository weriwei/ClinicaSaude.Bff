using System.Collections.Generic;
using System.Linq;

namespace ClinicaSaude.Bff.Borders.Dtos.HealthCheck
{
    public record HealthCheckStatus(string Version, IEnumerable<HealthCheckActivity> Activities)
    {
        public bool Success => Activities.All(activity => activity.Success);
    };
}