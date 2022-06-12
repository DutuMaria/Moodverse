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
    public class ToDoListTaskController : ControllerBase
    {
        // injectam contextul
        // parametrii de tip private se denumesc cu _
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public ToDoListTaskController(AppDbContext context, UserManager<User> userManager)
        {
            // ii dam contextul din startup
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("AddToDoListTask")]
        [Authorize("admin")]
        public async Task<IActionResult> AddToDoListTask([FromBody] ToDoListTask toDoListTask)
        {
            if (toDoListTask.Id == 0)
            {
                return BadRequest("Id is 0!");
            }

            await _context.ToDoListTasks.AddAsync(toDoListTask);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetToDoListTaskById/{id}")]
        public async Task<IActionResult> GetToDoListTaskById([FromRoute] int id)
        {
            var toDoListTask = await _context
                .ToDoListTasks
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(toDoListTask);
        }


        [HttpGet("GetToDoListIdById/{id}")]
        public async Task<IActionResult> GetToDoListIdById([FromRoute] int id)
        {
            var listId = 0;
            var tasks = await _context
                .ToDoListTasks
                .ToListAsync();
            foreach(var t in tasks)
            {
                if (t.Id == id)
                {
                    listId = t.ToDoListId;
                }
            }

            return Ok(listId);
        }


        [HttpGet("GetDoneById/{id}")]
        public async Task<IActionResult> GetDoneById([FromRoute] int id)
        {
            var done = 0;
            var tasks = await _context
                .ToDoListTasks
                .ToListAsync();
            foreach(var t in tasks)
            {
                if (t.Id == id)
                {
                    done = t.Done;
                }
            }

            return Ok(done);
        }


        [HttpGet("GetDescriptionById/{id}")]
        public async Task<IActionResult> GetDescriptionById([FromRoute] int id)
        {
            var descr = "";
            var tasks = await _context
                .ToDoListTasks
                .ToListAsync();
            foreach(var t in tasks)
            {
                if (t.Id == id)
                {
                    descr = t.Description;
                }
            }

            return Ok(descr);
        }

        [HttpGet("GetAllToDoListTasksByToDoListId/{id}")]
        // [Authorize("admin")]
        public async Task<IActionResult> GetAllToDoListTasksByToDoListId([FromRoute] int id)
        {
            var tasks = await _context
                .ToDoListTasks
                .Where(x => x.ToDoListId == id)
                .ToListAsync();

            return Ok(tasks);
        }
        

        [HttpGet("GetToDoListTasks")]
        // [Authorize("admin")]
        public async Task<IActionResult> GetToDoListTasks()
        {
            var toDoListTasks = await _context
                .ToDoListTasks
                .ToListAsync();
            return Ok(toDoListTasks);
        }


        [HttpPut("UpdateToDoListTask/{id}")]
        [Authorize("user")]
        public async Task<IActionResult> UpdateToDoListTask([FromRoute] int id, [FromBody] ToDoListTask toDoListTask)
        {
            var _toDoListTask = await _context.ToDoListTasks.FirstOrDefaultAsync(x => x.Id == id);
            if (_toDoListTask != null)
            {
                _toDoListTask.Id = toDoListTask.Id;
                _toDoListTask.ToDoListId = toDoListTask.ToDoListId;
                _toDoListTask.Done= toDoListTask.Done;
                _toDoListTask.Description = toDoListTask.Description;

                await _context.SaveChangesAsync();
            }
            return Ok();
        }



        [HttpDelete("DeleteToDoListTask/{id}")]
        [Authorize("user")]
        public async Task<IActionResult> DeleteToDoListTask([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is 0!");
            }

            var toDoListTask = await _context.ToDoListTasks.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(toDoListTask);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}