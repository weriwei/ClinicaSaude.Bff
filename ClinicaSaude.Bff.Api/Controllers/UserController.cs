using System.Threading.Tasks;
using ClinicaSaude.Bff.Api.Models;
using ClinicaSaude.Bff.Borders.Dtos;
using ClinicaSaude.Bff.Borders.Shared;
using ClinicaSaude.Bff.Borders.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSaude.Bff.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IActionResultConverter _actionResultConverter;
        private IUserLoginUseCase _userLoginUseCase;
        private IUserSignupUseCase _userSignupUseCase;

        public UserController(IActionResultConverter actionResultConverter, IUserLoginUseCase userLoginUseCase, IUserSignupUseCase userSignupUseCase)
        {
            _userLoginUseCase = userLoginUseCase;
            _actionResultConverter = actionResultConverter;
            _userSignupUseCase = userSignupUseCase;
        }

        /// <summary>
        /// Authenticate an user 
        /// </summary>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginRequest request)
        {
            var response = await _userLoginUseCase.Execute(request);
            return _actionResultConverter.Convert(response);
        }


        /// <summary>
        /// Create a user 
        /// </summary>
        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> UserSignup([FromBody] UserSignupRequest request)
        {
            var response = await _userSignupUseCase.Execute(request);
            return _actionResultConverter.Convert(response);
        }
    }
}
