using DsLine.Core.Models.Entities;
using System;
using System.Collections.Generic;

namespace DsLine.Orders.Models.Entities
{
    public class Order : Entity<Guid>
    {
        public Guid CustomerId { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
