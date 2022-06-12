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
    public class AmbienceController : ControllerBase
    {
        // injectam contextul
        // parametrii de tip private se denumesc cu _
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public AmbienceController(AppDbContext context, UserManager<User> userManager)
        {
            // ii dam contextul din startup
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("AddAmbience")]
        [Authorize("admin")]
        public async Task<IActionResult> AddAmbience([FromBody] Ambience ambience)
        {
            if (ambience.Id == 0)
            {
                return BadRequest("Id is 0!");
            }

            await _context.Ambience.AddAsync(ambience);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetAmbienceById/{id}")]
        public async Task<IActionResult> GetAmbienceById([FromRoute] int id)
        {
            var ambience = await _context
                .Ambience
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(ambience);
        }



        [HttpGet("GetSoundById/{id}")]
        public async Task<IActionResult> GetSoundById([FromRoute] int id)
        {
            var sound = "";
            var ambiences = await _context
                .Ambience
                .ToListAsync();
            foreach(var amb in ambiences)
            {
                if (amb.Id == id)
                {
                    sound = amb.Sound;
                }
            }

            return Ok(sound);
        }



        [HttpGet("GetAmbienceNameById/{id}")]
        public async Task<IActionResult> GetAmbienceNameById([FromRoute] int id)
        {
            var ambienceName = "";
            var ambiences = await _context
                .Ambience
                .ToListAsync();
            foreach(var amb in ambiences)
            {
                if (amb.Id == id)
                {
                    ambienceName = amb.AmbienceName;
                }
            }

            return Ok(ambienceName);
        }


        [HttpGet("GetAmbiences")]
        // [Authorize("admin")]
        public async Task<IActionResult> GetAmbiences()
        {
            var ambiences = await _context
                .Ambience
                .ToListAsync();
            return Ok(ambiences);
        }


        [HttpPut("UpdateAmbience/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> UpdateAmbience([FromRoute] int id, [FromBody] Ambience ambience)
        {
            var _ambience = await _context.Ambience.FirstOrDefaultAsync(x => x.Id == id);
            if (_ambience != null)
            {
                _ambience.Id = ambience.Id;
                _ambience.Sound = ambience.Sound;
                _ambience.AmbienceName= ambience.AmbienceName;

                await _context.SaveChangesAsync();
            }
            return Ok();
        }



        [HttpDelete("DeleteAmbience/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> DeleteAmbience([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is 0!");
            }

            var ambience = await _context.Ambience.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(ambience);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}