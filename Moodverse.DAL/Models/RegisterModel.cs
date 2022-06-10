using System;
namespace Moodverse.DAL.Models
{
    public class RegisterModel
    {
        public RegisterModel()
        {
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}
