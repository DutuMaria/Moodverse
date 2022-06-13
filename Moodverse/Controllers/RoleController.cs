using System;
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
    public class RoleController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly UserManager<User> _userManager;

        public RoleController(IAuthManager authManager, UserManager<User> userManager)
        {
            _authManager = authManager;
            _userManager = userManager;
        }

        [HttpGet("checkIfAdmin/{email}")]
        public async Task<IActionResult> checkIfAdmin([FromRoute] string email)
        { 
            var users = await _userManager.GetUsersInRoleAsync("admin");

            foreach (var user in users)
            {
                var username = user.Email;

                if (email == username)
                {
                    Console.Write(user.UserName);

                    return Ok(true);
                }
            }
            return Ok(false);
        }
    }
}
