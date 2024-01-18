using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/authorization")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequestDto body)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DataResult<JwtResponseDto> result = _authService.Login(body);
            return Ok(result);
        }

        [HttpPost("accessToken")]
        public IActionResult GetAccessToken([FromBody] RefreshTokenDto body)
        {
            DataResult<AccessTokenDto> result = _authService.GetAccessToken(body);
            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto user)
        {
            Result result = _userService.Create(user);
            return Ok(result);
        }
    }
}
