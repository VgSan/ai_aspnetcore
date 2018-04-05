using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aisys.Core
{
    [Table("Employee")]
    public class Employee : BaseEntity
    {
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
    }
}
