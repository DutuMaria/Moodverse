using System;
using System.ComponentModel.DataAnnotations;

namespace Moodverse.DAL.Entities
{
    public class ToDoListTask
    {
        public ToDoListTask()
        {
        }


        [Key]
        public int Id { get; set; }
        public int ToDoListId { get; set; }
        public bool Done { get; set; }
        public string Description { get; set; }
        public virtual ToDoList ToDoList { get; set; }
    }
}
