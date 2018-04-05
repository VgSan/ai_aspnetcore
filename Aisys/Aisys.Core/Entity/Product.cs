using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aisys.Core
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ProductGroup ProductGroup { get; set; }
    }

    [Table("ProductGroup")]
    public class ProductGroup : BaseEntity
    {
        public string Name { get; set; }
        public Template ProductTemplate { get; set; }
    }
}
