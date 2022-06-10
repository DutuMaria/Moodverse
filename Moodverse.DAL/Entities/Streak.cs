using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moodverse.DAL.Entities
{
    public class Streak
    {
        public Streak()
        {
        }


        [Key]
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime LastDate { get; set; }
        public virtual User User { get; set; }
    }
}
