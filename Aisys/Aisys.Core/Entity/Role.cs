using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aisys.Core
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        public string RoleCd { get; set; }
        public string RoleName { get; set; }
        public int Level { get; set; }
    }

    [Table("UserRole")]
    public class UserRole : BaseEntity
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
