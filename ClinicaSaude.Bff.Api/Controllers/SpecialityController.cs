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
    public class SpecialityController : ControllerBase
    {
        private readonly IActionResultConverter _actionResultConverter;
        private IGetSpecialitysUseCase _getSpecialitysUseCase;
        private IGetDoctorsUseCase _getDoctorsUseCase;

        public SpecialityController(IActionResultConverter actionResultConverter, IGetSpecialitysUseCase getSpecialitysUseCase, IGetDoctorsUseCase getDoctorsUseCase)
        {
            _actionResultConverter = actionResultConverter;
            _getSpecialitysUseCase = getSpecialitysUseCase;
            _getDoctorsUseCase = getDoctorsUseCase;
        }

        /// <summary>
        /// Get specialitys
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Speciality[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> GetSpecialitys()
        {
            var response = await _getSpecialitysUseCase.Execute();
            return _actionResultConverter.Convert(response);
        }

        /// <summary>
        /// Get doctors by speciality id
        /// </summary>
        [HttpGet("doctor/{speciality}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Doctor[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> GetDoctorsBySpecialityId(Guid speciality)
        {
            var response = await _getDoctorsUseCase.Execute(speciality);
            return _actionResultConverter.Convert(response);
        }
    }
}
