using System;
using System.Threading.Tasks;
using DatingApp.Entities;

namespace DatingApp_Backend.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
