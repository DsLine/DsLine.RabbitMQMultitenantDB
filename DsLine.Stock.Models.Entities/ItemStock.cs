using DsLine.Core.Models.Entities;
using System;

namespace DsLine.Stock.Models.Entities
{
    public class ItemStock : Entity<Guid>
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime TackingDate { get; set; }
    }
}