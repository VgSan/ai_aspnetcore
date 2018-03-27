using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aisys.Core
{
    [Table("User")]
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    [Table("UserToken")]
    public class UserToken : BaseEntity
    {
        public User User { get; set; }
        public string Token { get; set; }
        public int ExpireIn { get; set; }
    }
}
