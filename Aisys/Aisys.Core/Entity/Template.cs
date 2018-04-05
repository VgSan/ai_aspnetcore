using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aisys.Core
{
    [Table("Template")]
    public class Template : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
