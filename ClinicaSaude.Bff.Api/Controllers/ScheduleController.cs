using System;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Api.Models;
using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSaude.Bff.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IActionResultConverter _actionResultConverter;
        private IGetSchedulesUseCase _getSchedulesUseCase;

        public ScheduleController(IActionResultConverter actionResultConverter, IGetSchedulesUseCase getSchedulesUseCase)
        {
            _actionResultConverter = actionResultConverter;
            _getSchedulesUseCase = getSchedulesUseCase;
        }

        /// <summary>
        /// Get schedules by doctor id
        /// </summary>
        [HttpGet("{doctorId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Schedule[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> GetSchedulesByDoctorId(Guid doctorId)
        {
            var response = await _getSchedulesUseCase.Execute(doctorId);
            return _actionResultConverter.Convert(response);
        }
    }
}
