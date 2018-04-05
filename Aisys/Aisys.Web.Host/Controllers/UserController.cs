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
        public async Task CreateUser([FromBody] UserInput input)
        {
            await _userService.CreateUser(input);
        }

        [HttpPut("UpdateUser")]
        public async Task UpdateUser([FromBody] UserDto input)
        {
            await _userService.UpdateUser(input);
        }

        [HttpDelete("DeleteUser")]
        public async Task DeleteUser(string ids)
        {
            List<int> idsArr = ids.Split(',').Select(int.Parse).ToList();
            await _userService.DeleteUser(idsArr);
        }
    }
}