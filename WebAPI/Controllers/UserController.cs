using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    //[Authorize(Roles = "ADMIN")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult GetMe()
        {
            var email = User.Identity?.Name!;
            DataResult<UserDto> user = _userService.GetUserByEmail(email);
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            DataResult<ICollection<UserDto>> result = _userService.GetAll();
            return StatusCode(200, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            DataResult<UserDto> result = _userService.GetById(id);
            return StatusCode(200, result);
        }

        [ValidationFilter]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            Result result = _userService.Create(user);
            return StatusCode(201, result);
        }

    }
}
