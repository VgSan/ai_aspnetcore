using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aisys.Application;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace Aisys.Web.Host.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        IUserService _userService;

        public UserController(IMapper mapper,
            IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public List<UserDto> GetUsers()
        {
            List<UserDto> userList = _userService.GetUsers();
            return userList;
        }

        [HttpPost("CreateUser")]
        public async Task CreateUser(UserInput input)
        {
            await _userService.CreateUser(input);
        }

        [HttpPost("UpdateUser")]
        public async Task UpdateUser(UserDto input)
        {
            await _userService.UpdateUser(input);
        }

        [HttpPost("DeleteUser")]
        public async Task DeleteUser(int UserId)
        {
            await _userService.DeleteUser(UserId);
        }
    }
}