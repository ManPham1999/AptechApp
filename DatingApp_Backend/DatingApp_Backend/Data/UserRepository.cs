using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Data;
using DatingApp.Entities;
using DatingApp_Backend.DTO;
using DatingApp_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingApp_Backend.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<MemberDTO> GetMemberAsync(string username)
        {
            return await _context.Users.Where(x => x.UserName == username).Select(user => new MemberDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain).Url,
                Age = user.GetAge(),
                KnownAs = user.KnownAs,
                Created = user.Created,
                LastActive = user.LastActive,
                Gender = user.Gender,
                Introduction = user.Introduction,
                LookingFor = user.LookingFor,
                Interests = user.Interests,
                City = user.City,
                Country = user.Country,
                Photos = user.Photos.Select(photo => new PhotoDTO
                {
                    Id = photo.Id,
                    Url = photo.Url,
                    IsMain = photo.IsMain
                }).ToList()
            }).SingleOrDefaultAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users.Include(p => p.Photos).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
