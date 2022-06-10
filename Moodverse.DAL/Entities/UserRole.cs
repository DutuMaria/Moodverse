using System;
using Microsoft.AspNetCore.Identity;

namespace Moodverse.DAL.Entities
{
    public class UserRole : IdentityUserRole<int>
    {
        public UserRole()
        {
        }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
