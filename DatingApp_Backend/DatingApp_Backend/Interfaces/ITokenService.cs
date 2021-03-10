using System;
using DatingApp.Entities;

namespace DatingApp_Backend.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
