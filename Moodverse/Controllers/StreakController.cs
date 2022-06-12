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

        [HttpPost("AddStreak")]
        public async Task<IActionResult> AddStreak([FromBody] Streak streak)
        {
            if (streak.Id == 0)
            {
                return BadRequest("Id is 0!");
            }

            streak.LastDate = LastDate.Today;
            streak.NumberOfDays = 1;

            await _context.Streak.AddAsync(streak);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetStreakById/{id}")]
        public async Task<IActionResult> GetStreakById([FromRoute] int id)
        {
            var streak = await _context
                .Streak
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(streak);
        }


        [HttpGet("GetUserIdById/{id}")]
        public async Task<IActionResult> GetUserIdById([FromRoute] int id)
        {
            var userId = 0;
            var streaks = await _context
                .Streak
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(userId.UserId);
        }


        [HttpGet("GetNumberOfDaysById/{id}")]
        public async Task<IActionResult> GetNumberOfDaysById([FromRoute] int id)
        {
            var nod = "";
            var streaks = await _context
                .Streak
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
            var lastDate = "";
            var streaks = await _context
                .Streak
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
            var _streak = await _context.Streak.FirstOrDefaultAsync(x => x.Id == id);
            if (_streak != null)
            {
                var yesterday = DateTime.Today.AddDays(-1).toString("yyyy-MM-dd");

                if (_streak.LastDate.toString("yyyy-MM-dd") == yesterday)
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