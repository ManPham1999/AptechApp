using DatingApp.Entities;
using Microsoft.AspNetCore.Identity;

namespace api.Entities
{
    public class AppUsersRole : IdentityUserRole<int>
    {
        public AppUser Users { get; set; }
        public AppRole Role { get; set; }
    }
}