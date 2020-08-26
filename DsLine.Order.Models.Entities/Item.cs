using DsLine.Core.Models.Entities;
using System;

namespace DsLine.Orders.Models.Entities
{
    public class Item : Entity<Guid>
    {
        public string Name { get; set; }
    }
}
