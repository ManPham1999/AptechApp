using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp_Backend.Controllers
{
    public class UserController : BaseController
    {
        private DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsers()
        {
            var userList = await _context.Users.ToListAsync();
            if (userList.Count > 0)
            {
                return Ok(userList);
            }
            else
            {
                return StatusCode(400, "No user found.");
            }
        } 
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            if (await CheckUserExist(id))
            {
                return Ok(await _context.Users.FindAsync(id)); 
            }
            else
            {
                return StatusCode(400,"User not found!"); 
            }
        }

        public async Task<bool> CheckUserExist(int id)
        {
            var result = await _context.Users.FindAsync(id);
            return !result.Equals(null);
        }
    }
}