using System;
using System.Collections.Generic;
using api.Entities;
using DatingApp_Backend.Entities;
using DatingApp_Backend.Extensions;
using Microsoft.AspNetCore.Identity;

namespace DatingApp.Entities
{
    public class AppUser : IdentityUser<int>
    {
        //public int Id { get; set; }
        //public string UserName { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
        public DateTime Dob { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<AppUsersRole> UserRoles { get; set; }
        public int GetAge()
        {
            return CalculateAge.CalculatedAge(Dob);
        }
    }
}
