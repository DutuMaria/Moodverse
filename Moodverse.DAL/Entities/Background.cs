using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moodverse.DAL.Entities
{
    public class Background
    {
        public Background()
        {
        }

        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string BackgroundName { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
