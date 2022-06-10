using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Moodverse.DAL.Entities;

namespace Moodverse.BLL.Interfaces
{
    public interface ITokenHelper
    {
        Task<string> CreateAccessToken(User user);
        string CreateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string _Token);
    }
}
