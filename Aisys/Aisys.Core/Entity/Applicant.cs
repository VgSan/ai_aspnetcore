﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aisys.Core
{
    [Table("Applicant")]
    public class Applicant : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MailAddress { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }

        public ICollection<Experience> Experiences { get; set; }
    }
}
