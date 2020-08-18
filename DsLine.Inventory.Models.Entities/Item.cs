using DsLine.Core.Models.Entities;
using System;
using System.Collections.Generic;

namespace DsLine.Inventory.Models.Entities
{
    public class Item : Entity<Guid>
    {
        public Guid CustomerId { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
