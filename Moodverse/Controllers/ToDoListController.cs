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
    public class ToDoListController : ControllerBase
    {
        // injectam contextul
        // parametrii de tip private se denumesc cu _
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public ToDoListController(AppDbContext context, UserManager<User> userManager)
        {
            // ii dam contextul din startup
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("AddToDoList")]
        [Authorize("user")]
        public async Task<IActionResult> AddToDoList([FromBody] ToDoList toDoList)
        {
            if (toDoList.Id == 0)
            {
                return BadRequest("Id is 0!");
            }

            await _context.ToDoLists.AddAsync(toDoList);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetToDoListById/{id}")]
        public async Task<IActionResult> GetToDoListById([FromRoute] int id)
        {
            var toDoList = await _context
                .ToDoLists
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(toDoList);
        }

        [HttpGet("GetUserIdById/{id}")]
        public async Task<IActionResult> GetUserIdById([FromRoute] int id)
        {
            var userId = 0;
            var lists = await _context
                .ToDoLists
                .ToListAsync();
            foreach(var l in lists)
            {
                if (l.Id == id)
                {
                    userId = l.UserId;
                }
            }

            return Ok(userId);
        }


        [HttpGet("GetTitleById/{id}")]
        public async Task<IActionResult> GetTitleById([FromRoute] int id)
        {
            var title = "";
            var lists = await _context
                .ToDoLists
                .ToListAsync();
            foreach(var l in lists)
            {
                if (l.Id == id)
                {
                    title = l.Title;
                }
            }

            return Ok(title);
        }

                
        [HttpGet("GetProgressById/{id}")]
        public async Task<IActionResult> GetProgressById([FromRoute] int id)
        {
            var progress = 0.0m;
            var lists = await _context
                .ToDoLists
                .ToListAsync();
            foreach(var l in lists)
            {
                if (l.Id == id)
                {
                    progress = l.Progress;
                }
            }

            return Ok(progress);
        }

                
        [HttpGet("GetToDoListTasksById/{id}")]
        public async Task<IActionResult> GetTasksById([FromRoute] int id)
        {
            var tasksList = await _context
                .ToDoListTasks
                .Where(x => x.ToDoListId == id)
                .ToListAsync();

            return Ok(tasksList);
        }


        [HttpGet("GetToDoLists")]
        // [Authorize("admin")]
        public async Task<IActionResult> GetToDoLists()
        {
            var toDoLists = await _context
                .ToDoLists
                .ToListAsync();
            return Ok(toDoLists);
        }


        [HttpPut("UpdateToDoList/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> UpdateToDoList([FromRoute] int id, [FromBody] ToDoList toDoList)
        {
            var _toDoList = await _context.ToDoLists.FirstOrDefaultAsync(x => x.Id == id);
            if (_toDoList != null)
            {
                _toDoList.Id = toDoList.Id;
                _toDoList.UserId = toDoList.UserId;
                _toDoList.Title= toDoList.Title;
                _toDoList.Progress = toDoList.Progress;
                _toDoList.ToDoListTasks = toDoList.ToDoListTasks;


                await _context.SaveChangesAsync();
            }
            return Ok();
        }



        [HttpDelete("DeleteToDoList/{id}")]
        [Authorize("user")]
        public async Task<IActionResult> DeleteToDoList([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is 0!");
            }

            var toDoList = await _context.ToDoLists.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(toDoList);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}