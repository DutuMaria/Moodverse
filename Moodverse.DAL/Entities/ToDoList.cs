using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moodverse.DAL.Entities
{
    public class ToDoList
    {
        public ToDoList()
        {
        }

        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public double Progress { get; set; }
        public virtual ICollection<ToDoListTask> ToDoListTasks { get; set; }
        public virtual User User { get; set; }

    }
}
