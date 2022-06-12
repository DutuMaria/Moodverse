using System;
using Microsoft.AspNetCore.Identity;
using Moodverse.DAL.Entities;

namespace Moodverse.DAL
{
    public class InitialSeed
    {
        private readonly RoleManager<Role> _roleManager;

        public InitialSeed(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void CreateRoles()
        {
            string[] roleNames =
            {
                "admin",
                "user"
            };

            foreach (var name in roleNames)
            {
                var role = new Role
                {
                    Name = name
                };

                _roleManager.CreateAsync(role).Wait();
            }
        }
    }
}





