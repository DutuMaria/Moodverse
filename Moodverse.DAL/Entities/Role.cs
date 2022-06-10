using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Moodverse.DAL.Entities
{
    public class Role : IdentityRole<int>
    {
        public Role()
        {
        }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
