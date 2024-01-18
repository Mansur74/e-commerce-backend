﻿using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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



        [HttpGet]
        public IActionResult GetUsers()
        {
            DataResult<ICollection<UserDto>> users = _userService.GetAll();
            return StatusCode(200, users);
        }

       
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            Result result = _userService.Create(user);
            return StatusCode(201, result);
        }

    }
}
