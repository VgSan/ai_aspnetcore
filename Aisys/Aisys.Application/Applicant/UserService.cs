﻿using AutoMapper;
using Aisys.Core;
using Aisys.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aisys.Application
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        IGenericRepository<User> _userRepository;

        public UserService(IMapper mapper,
            IGenericRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task CreateUser(UserInput input)
        {
            User result = _mapper.Map<User>(input);
            await _userRepository.Create(result);
        }

        public async Task DeleteUser(int UserId)
        {
            await _userRepository.Delete(UserId);
        }

        public List<UserDto> GetUsers()
        {
            List<User> listOfExperince = _userRepository.GetAll().ToList();
            var result = _mapper.Map<List<UserDto>>(listOfExperince);

            return result;
        }

        public async Task UpdateUser(UserDto input)
        {
            User result = _mapper.Map<User>(input);
            result.ModifiedDate = DateTime.Now;

            await _userRepository.Update(input.Id, result);
        }
    }
}
