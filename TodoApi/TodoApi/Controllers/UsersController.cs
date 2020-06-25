﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models.Api;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(RegisterData data)
        {
            var user = await userService.Register(data, ModelState);
            if (user == null)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            return user;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Login(LoginData data)
        {
            var user = await userService.Authenticate(data.Username, data.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }

        [HttpGet("Self")]
        [Authorize]
        public async Task<ActionResult<User>> Self()
        {
            return await userService.GetUser(User);
        }
    }
}
