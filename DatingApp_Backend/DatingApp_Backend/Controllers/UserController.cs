using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Data;
using DatingApp.Entities;
using DatingApp_Backend.Data;
using DatingApp_Backend.DTO;
using DatingApp_Backend.Interfaces;
using DatingApp_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp_Backend.Controllers
{
    public class UserController : BaseController
    {
        readonly ILogger<UserController> _log;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> log, IUserRepository userRepository, IMapper mapper)
        {
            _log = log;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetAllUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return Ok(_mapper.Map<IEnumerable<MemberDTO>>(users));
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDTO>> GetUser(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            return Ok(_mapper.Map<MemberDTO>(user));
        }

        [HttpGet("second/{username}")]
        public async Task<ActionResult<MemberDTO>> GetMember(string username)
        {
            return Ok(await _userRepository.GetMemberAsync(username));
        }

        //[Authorize]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<MemberDTO>> GetUserById(int id)
        //{
        //    var user = await _userRepository.GetUserByIdAsync(id);
        //    if (await CheckUserExist(id))
        //    {
        //        return Ok(_mapper.Map<MemberDTO>(user)); 
        //    }
        //    else
        //    {
        //        return StatusCode(400,"User not found!"); 
        //    }
        //}


        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDTO memberUpdate)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetUserByUsernameAsync(username);
            _mapper.Map(memberUpdate, user);
            if (await _userRepository.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("Fail to update user");
        }

        public async Task<bool> CheckUserExist(int id)
        {
            var result = await _userRepository.GetUserByIdAsync(id);
            return !result.Equals(null);
        }
    }
}