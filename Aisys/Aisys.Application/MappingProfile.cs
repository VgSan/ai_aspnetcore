using AutoMapper;
using Aisys.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aisys.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects

            CreateMap<Employee, EmployeeDto>()
                .ReverseMap();
            CreateMap<Employee, EmployeeInput>()
                .ReverseMap();

            CreateMap<User, UserDto>()
                .ReverseMap();
            CreateMap<User, UserInput>()
                .ReverseMap();
            
        }
    }
}
