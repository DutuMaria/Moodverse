using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moodverse.DAL;
using Moodverse.DAL.Entities;

namespace Moodverse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreakController : ControllerBase
    {
        // injectam contextul
        // parametrii de tip private se denumesc cu _
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public StreakController(AppDbContext context, UserManager<User> userManager)
        {
            // ii dam contextul din startup
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("AddStreak/{idUser}")]
        public async Task<IActionResult> AddStreak([FromRoute] int idUser)
        {
            var streak = new Streak();
            //streak.Id = idUser;
            streak.UserId = idUser;
            streak.LastDate = DateTime.Today;
            streak.NumberOfDays = 0;

            var users = await _userManager.GetUsersInRoleAsync("user");
            await _context.Streaks.AddAsync(streak);
            await _context.SaveChangesAsync();

            foreach (var user in users)
            {
                var id = user.Id;
                Console.Write("2-------------------------");

                if (id == idUser)
                {
                    user.IdStreak = streak.Id;
                }
            }

            return NoContent();
        }

        [HttpGet("GetStreakById/{id}")]
        public async Task<IActionResult> GetStreakById([FromRoute] int id)
        {
            var streak = await _context
                .Streaks
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(streak);
        }


        [HttpGet("GetUserIdById/{id}")]
        public async Task<IActionResult> GetUserIdById([FromRoute] int id)
        {
            var userId = 0;
            var streaks = await _context
                .Streaks
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(userId);
        }


        [HttpGet("GetNumberOfDaysById/{id}")]
        public async Task<IActionResult> GetNumberOfDaysById([FromRoute] int id)
        {
            var nod = 0;
            var streaks = await _context
                .Streaks
                .ToListAsync();
            foreach(var stk in streaks)
            {
                if (stk.Id == id)
                {
                    nod = stk.NumberOfDays;
                }
            }

            return Ok(nod);
        }


        [HttpGet("GetLastDateById/{id}")]
        public async Task<IActionResult> GetLastDateById([FromRoute] int id)
        {
            DateTime lastDate = DateTime.Now;
            var streaks = await _context
                .Streaks
                .ToListAsync();
            foreach(var stk in streaks)
            {
                if (stk.Id == id)
                {
                    lastDate = stk.LastDate;
                }
            }

            return Ok(lastDate);
        }


        // [HttpPut("UpdateStreak/{id}")]
        // [Authorize("admin")]
        // public async Task<IActionResult> UpdateStreak([FromRoute] int id, [FromBody] Streak streak)
        // {
        //     var _streak = await _context.Streak.FirstOrDefaultAsync(x => x.Id == id);
        //     if (_streak != null)
        //     {
        //         _streak.Id = streak.Id;
        //         _streak.UserId = streak.UserId;
        //         _streak.NumberOfDays= streak.NumberOfDays;
        //         _streak.LastDate = streak.LastDate;
        //         _streak.User = streak.User;


        //         await _context.SaveChangesAsync();
        //     }
        //     return Ok();
        // }


        [HttpPut("UpdateStreak/{id}")]
        public async Task<IActionResult> UpdateStreak([FromRoute] int id, [FromBody] Streak streak)
        {
            var _streak = await _context.Streaks.FirstOrDefaultAsync(x => x.Id == id);
            if (_streak != null)
            {
                var yesterday = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");

                if (_streak.LastDate.ToString("yyyy-MM-dd") == yesterday)
                {
                    _streak.NumberOfDays += 1;
                }
                else 
                {
                    _streak.NumberOfDays = 1;
                }

                _streak.LastDate = streak.LastDate;
            
                await _context.SaveChangesAsync();
            }
            return Ok();
        }


    }
}