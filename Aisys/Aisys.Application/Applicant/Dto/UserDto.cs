using System;
using System.Collections.Generic;
using System.Text;

namespace Aisys.Application
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserInput
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
