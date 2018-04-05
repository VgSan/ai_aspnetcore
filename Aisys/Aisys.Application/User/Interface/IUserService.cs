using Aisys.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aisys.Application
{
    public interface IUserService
    {
        List<UserDto> GetUsers();
        Task CreateUser(UserInput input);
        Task UpdateUser(UserDto input);
        Task DeleteUser(List<int> ids);
    }
}
