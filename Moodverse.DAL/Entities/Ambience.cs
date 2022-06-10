using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moodverse.DAL.Entities
{
    public class Ambience
    {
        public Ambience()
        {
        }

        [Key]
        public int Id { get; set; }
        public string Sound { get; set; }
        public string AmbienceName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
