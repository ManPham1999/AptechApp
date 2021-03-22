using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Entities;
using DatingApp_Backend.DTO;

namespace DatingApp_Backend.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<AppUser>> GetUsersAsync();

        Task<AppUser> GetUserByIdAsync(int id);

        Task<AppUser> GetUserByUsernameAsync(string username);

        Task<MemberDTO> GetMemberAsync(string username);
    }
}
