using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Moodverse.DAL.Entities
{
    public class User : IdentityUser<int>
    {
        public User()
        {
        }

        public int IdBackground { get; set; }
        public int IdTimer { get; set; }
        public int IdAmbience { get; set; }
        public int IdDailyQuote { get; set; }
        public int IdToDoList { get; set; }
        public int IdStreak { get; set; }

        public string RefreshToken { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual Background Background { get; set; }
        public virtual Timer Timer { get; set; }
        public virtual Ambience Ambience { get; set; }
        public virtual DailyQuote DailyQuote { get; set; }
        public virtual ToDoList ToDoList { get; set; }
        public virtual Streak Streak { get; set; }
    }
}
