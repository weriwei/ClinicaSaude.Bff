using System;
using System.Threading.Tasks;
using ClinicaSaude.Bff.Api.Models;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Entities;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSaude.Bff.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IActionResultConverter _actionResultConverter;
        private ICreateAppointmentUseCase _createAppointmentUseCase;
        private IGetAppointmentsUseCase _getAppointmentsUseCase;

        public AppointmentController(IActionResultConverter actionResultConverter, ICreateAppointmentUseCase createAppointmentUseCase, IGetAppointmentsUseCase getAppointmentsUseCase)
        {
            _actionResultConverter = actionResultConverter;
            _createAppointmentUseCase = createAppointmentUseCase;
            _getAppointmentsUseCase = getAppointmentsUseCase;
        }

        /// <summary>
        /// Create an appointment
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> UserSignup([FromBody] AppointmentRequest request)
        {
            var response = await _createAppointmentUseCase.Execute(request);
            return _actionResultConverter.Convert(response);
        }

        /// <summary>
        /// Get appointments by patient id
        /// </summary>
        [HttpGet("{patientId}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AppointmentResponse[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> GetAppointmentsByPatientId(Guid patientId)
        {
            var response = await _getAppointmentsUseCase.Execute(patientId);
            return _actionResultConverter.Convert(response);
        }
    }
}
