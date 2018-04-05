using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aisys.Core
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        public string OrderNo { get; set; }
        public Client Client { get; set; }
        public DateTime PlaceDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    [Table("OrderDetail")]
    public class OrderDetail : BaseEntity
    {
        public string OrderNo { get; set; }
        public DateTime ActionDate { get; set; }
        public string ActionCode { get; set; }
        public string ActionType { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string Addressline3 { get; set; }
    }

    [Table("OrderProcess")]
    public class OrderProcess : BaseEntity
    {
        public Order Order { get; set; }
        public Employee Employee { get; set; }
        public string Status { get; set; }
    }
}