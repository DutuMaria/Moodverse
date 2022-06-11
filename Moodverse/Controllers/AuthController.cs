using Moodverse.BLL.Interfaces;
using Moodverse.DAL.Models;
using Moodverse.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Moodverse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly UserManager<User> _userManager;

        public AuthController(IAuthManager authManager, UserManager<User> userManager)
        {
            _authManager = authManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _authManager.Register(model);

            if (result)
                return Ok("Registered");
            else return BadRequest("Not registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _authManager.Login(model);

            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshModel model)
        {
            var result = await _authManager.Refresh(model);

            return Ok(result);
        }

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("user");

            return Ok(users);
        }

        [HttpGet("getUserId/{email}")]
        public async Task<IActionResult> GetUserId([FromRoute] string email)
        {
            var users = await _userManager.GetUsersInRoleAsync("user");

            foreach (var user in users)
            {
                var username = user.Email;

                if (email == username)
                {
                    return Ok(user.Id);
                }
            }

            return BadRequest("Not found!");
        }
    }
}
