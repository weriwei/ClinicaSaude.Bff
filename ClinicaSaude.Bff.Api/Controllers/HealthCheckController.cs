using System.Threading.Tasks;
using ClinicaSaude.Bff.Api.Models;
using ClinicaSaude.Bff.Borders.Dtos.HealthCheck;
using ClinicaSaude.Bff.Borders.UseCases.HealthCheck;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSaude.Bff.Api.Controllers
{
    [ApiController]
    [Route("api/healthcheck")]
    public class HealthCheckController : ControllerBase
    {

        private readonly IActionResultConverter actionResultConverter;
        private readonly IGetHealthCheckStatusUseCase getHealthCheckStatusUseCase;

        public HealthCheckController(
            IActionResultConverter actionResultConverter, IGetHealthCheckStatusUseCase getHealthCheckStatusUseCase)
        {
            this.actionResultConverter = actionResultConverter;
            this.getHealthCheckStatusUseCase = getHealthCheckStatusUseCase;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(HealthCheckStatus))]
        [ProducesResponseType(503, Type = typeof(HealthCheckStatus))]
        public async Task<IActionResult> Get()
        {
            var response = await getHealthCheckStatusUseCase.Execute();
            return actionResultConverter.Convert(response);
        }

        [HttpGet("ping")]
        [ProducesResponseType(200)]
        public IActionResult GetPong()
        {
            return Ok();
        }
    }
}
