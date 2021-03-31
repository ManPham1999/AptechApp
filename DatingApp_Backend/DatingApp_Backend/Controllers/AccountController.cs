using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Data;
using DatingApp.Entities;
using DatingApp_Backend.DTO;
using DatingApp_Backend.Interfaces;
using DatingApp_Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingApp_Backend.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        // GET: /<controller>/
        private readonly ITokenService _token;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _token = tokenService;

        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (await CheckUserExist(registerDTO))
            {
                using var hmac = new HMACSHA512();

                var user = new AppUser()
                {
                    UserName = registerDTO.UserName.ToLower(),
                    //PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.PassWord)),
                    //PasswordSalt = hmac.Key
                };

                var result = await _userManager.CreateAsync(user, registerDTO.PassWord);
                if (!result.Succeeded)
                {
                    return BadRequest();
                }
                return new UserDTO
                {
                    UserName = user.UserName,
                    Token = await _token.CreateTokenAsync(user)
                };
            }
            else
            {
                return StatusCode(400, "this user existed");
            }
            
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDTO.UserName);
            if (user == null)
            {
                return Unauthorized("Invalid UserName");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.PassWord, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            return new UserDTO
            {
                UserName = user.UserName,
                Token = await _token.CreateTokenAsync(user)
            }; 

        }
        public async Task<bool> CheckUserExist(RegisterDTO registerDTO)
        {
            return !(await _userManager.Users.AnyAsync(x => x.UserName == registerDTO.UserName));
        }

    }
}
