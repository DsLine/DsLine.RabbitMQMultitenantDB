using DsLine.Core.Models.Entities;
using System;

namespace DsLine.Orders.Models.Entities
{
    public class OrderItem : Entity<Guid>
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class ItemStock : Entity<Guid>
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
     
    }
}
