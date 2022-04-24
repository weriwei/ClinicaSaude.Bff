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
    public class DependentController : ControllerBase
    {
        private readonly IActionResultConverter _actionResultConverter;
        private IGetDependentUseCase _getDependentUseCase;
        private ICreateDependentUseCase _createDependentUseCase;

        public DependentController(IActionResultConverter actionResultConverter, IGetDependentUseCase getDependentUseCase, ICreateDependentUseCase createDependentUseCase)
        {
            _actionResultConverter = actionResultConverter;
            _getDependentUseCase = getDependentUseCase;
            _createDependentUseCase = createDependentUseCase;
        }

        /// <summary>
        /// Create dependents 
        /// </summary>
        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> CreateDependent(DependentSignupRequest request)
        {
            var response = await _createDependentUseCase.Execute(request);
            return _actionResultConverter.Convert(response);
        }

        /// <summary>
        /// Get dependents by userId
        /// </summary>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dependent[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> GetDependentsByUserId(Guid userId)
        {
            var response = await _getDependentUseCase.Execute(userId);
            return _actionResultConverter.Convert(response);
        }

    }
}
