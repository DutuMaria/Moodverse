using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moodverse.DAL.Entities
{
    public class DailyQuote
    {
        public DailyQuote()
        {
        }

        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
