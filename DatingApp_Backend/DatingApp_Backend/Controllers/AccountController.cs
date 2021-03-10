using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Data;
using DatingApp.Entities;
using DatingApp_Backend.DTO;
using DatingApp_Backend.Interfaces;
using DatingApp_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingApp_Backend.Controllers
{
    public class AccountController : BaseController
    {
        // GET: /<controller>/
        private readonly DataContext _context;
        private readonly ITokenService _token;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _token = tokenService;

        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDTO registerDTO)
        {
            if (await CheckUserExist(registerDTO))
            {
                using var hmac = new HMACSHA512();

                var user = new AppUser()
                {
                    UserName = registerDTO.UserName.ToLower(),
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.PassWord)),
                    PasswordSalt = hmac.Key
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return StatusCode(200, user);
            }
            else
            {
                return StatusCode(400, "this user existed");
            }
            
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDTO.UserName);
            if (user == null)
            {
                return Unauthorized("Invalid UserName");
            }
            var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.PassWord));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password");
                }
            }

            return new UserDTO
            {
                UserName = user.UserName,
                Token = _token.CreateToken(user)
            }; 

        }
        public async Task<bool> CheckUserExist(RegisterDTO registerDTO)
        {
            return !(await _context.Users.AnyAsync(x => x.UserName == registerDTO.UserName));
        }

    }
}
