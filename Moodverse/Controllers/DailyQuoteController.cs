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
    public class DailyQuoteController : ControllerBase
    {
        // injectam contextul
        // parametrii de tip private se denumesc cu _
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public DailyQuoteController(AppDbContext context, UserManager<User> userManager)
        {
            // ii dam contextul din startup
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("AddDailyQuote")]
        [Authorize("admin")]
        public async Task<IActionResult> AddDailyQuote([FromBody] DailyQuote dailyQuote)
        {
            if (dailyQuote.Id == 0)
            {
                return BadRequest("Id is 0!");
            }

            await _context.DailyQuotes.AddAsync(dailyQuote);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetDailyQuoteById/{id}")]
        public async Task<IActionResult> GetDailyQuoteById([FromRoute] int id)
        {
            var dailyQuote = await _context
                .DailyQuotes
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(dailyQuote);
        }


        [HttpGet("GetAuthorById/{id}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] int id)
        {
            var author = "";
            var dailyQuotes = await _context
                .DailyQuotes
                .ToListAsync();
            foreach(var dq in dailyQuotes)
            {
                if (dq.Id == id)
                {
                    author = dq.Author;
                }
            }

            return Ok(author);
        }

        [HttpGet("GetMessageById/{id}")]
        public async Task<IActionResult> GetMessageById([FromRoute] int id)
        {
            var message = "";
            var dailyQuotes = await _context
                .DailyQuotes
                .ToListAsync();
            foreach(var dq in dailyQuotes)
            {
                if (dq.Id == id)
                {
                    message = dq.Message;
                }
            }

            return Ok(message);
        }


        [HttpGet("GetDailyQuotes")]
        // [Authorize("admin")]
        public async Task<IActionResult> GetDailyQuotes()
        {
            var dailyQuotes = await _context
                .DailyQuotes
                .ToListAsync();
            return Ok(dailyQuotes);
        }


        [HttpPut("UpdateDailyQuote/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> UpdateDailyQuote([FromRoute] int id, [FromBody] DailyQuote dailyQuote)
        {
            var _dailyQuote = await _context.DailyQuotes.FirstOrDefaultAsync(x => x.Id == id);
            if (_dailyQuote != null)
            {
                _dailyQuote.Id = dailyQuote.Id;
                _dailyQuote.Author = dailyQuote.Author;
                _dailyQuote.Message= dailyQuote.Message;

                await _context.SaveChangesAsync();
            }

            return Ok();
        }



        [HttpDelete("DeleteDailyQuote/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> DeleteDailyQuote([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is 0!");
            }

            var dailyQuote = await _context.DailyQuotes.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(dailyQuote);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}