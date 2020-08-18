using System;

namespace DsLine.Orders.Services.Api.Dto
{
    public class ItemStockDTO
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public DateTime TackingDate { get; set; }
    }
}
