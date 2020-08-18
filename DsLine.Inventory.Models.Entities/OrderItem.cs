using DsLine.Core.Models.Entities;
using System;

namespace DsLine.Inventory.Models.Entities
{
    public class OrderItem : Entity<Guid>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
