using System;
namespace Moodverse.DAL.Models
{
    public class RefreshModel
    {
        public RefreshModel()
        {
        }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
