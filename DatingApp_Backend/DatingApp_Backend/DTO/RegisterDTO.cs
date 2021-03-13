using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp_Backend.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(8,MinimumLength =4)]
        public string  PassWord { get; set; }
        public RegisterDTO()
        {
        }
    }
}
