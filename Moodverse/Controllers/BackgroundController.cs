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
    public class BackgroundController : ControllerBase
    {
        // injectam contextul
        // parametrii de tip private se denumesc cu _
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public BackgroundController(AppDbContext context, UserManager<User> userManager)
        {
            // ii dam contextul din startup
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("AddBackground")]
        [Authorize("admin")]
        public async Task<IActionResult> AddBackground([FromBody] Background background)
        {
            if (background.Id == 0)
            {
                return BadRequest("Id is 0!");
            }

            await _context.Backgrounds.AddAsync(background);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetBackgroundById/{id}")]
        public async Task<IActionResult> GetBackgroundById([FromRoute] int id)
        {
            var background = await _context
                .Backgrounds
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(background);
        }


        [HttpGet("GetImageById/{id}")]
        public async Task<IActionResult> GetImageById([FromRoute] int id)
        {
            var image = "";
            var backgrounds = await _context
                .Backgrounds
                .ToListAsync();
            foreach(var bck in backgrounds)
            {
                if (bck.Id == id)
                {
                    image = bck.Image;
                }
            }

            return Ok(image);
        }

        [HttpGet("GetBackgroundNameById/{id}")]
        public async Task<IActionResult> GetBackgroundNameById([FromRoute] int id)
        {
            var backgroundName = "";
            var backgrounds = await _context
                .Backgrounds
                .ToListAsync();
            foreach(var bck in backgrounds)
            {
                if (bck.Id == id)
                {
                    backgroundName = bck.BackgroundName;
                }
            }

            return Ok(backgroundName);
        }
        

        [HttpGet("GetBackgrounds")]
        // [Authorize("admin")]
        public async Task<IActionResult> GetBackgrounds()
        {
            var backgrounds = await _context
                .Backgrounds
                .ToListAsync();
            return Ok(backgrounds);
        }



        [HttpPut("UpdateBackground/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> UpdateBackground([FromRoute] int id, [FromBody] Background background)
        {
            var _background = await _context.Backgrounds.FirstOrDefaultAsync(x => x.Id == id);
            if (_background != null)
            {
                _background.Id = background.Id;
                _background.Image = background.Image;
                _background.BackgroundName= background.BackgroundName;

                await _context.SaveChangesAsync();
            }

            return Ok();
        }



        [HttpDelete("DeleteBackground/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> DeleteBackground([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is 0!");
            }

            var background = await _context.Backgrounds.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(background);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}