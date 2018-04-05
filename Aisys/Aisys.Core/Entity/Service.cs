using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aisys.Core
{
    [Table("Service")]
    public class Service : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ServiceGroup ServiceGroup { get; set; }
    }

    [Table("ServiceGroup")]
    public class ServiceGroup : BaseEntity
    {
        public string Name { get; set; }
        public Template Template { get; set; }
    }
}