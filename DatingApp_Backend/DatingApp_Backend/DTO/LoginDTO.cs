using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp_Backend.DTO
{
    public class LoginDTO
    {
        [Required]
        public string  UserName { get; set; }
        [Required]
        public string PassWord {get; set;}
        public LoginDTO()
        {
        }
    }
}
