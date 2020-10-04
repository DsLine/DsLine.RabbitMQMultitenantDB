using DShop.Common.Messages;
using DsLine.Orders.Models.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DsLine.Orders.Services.Api.Messages.Commands
{
    public class UpdateStockEvent : IEvent
    {
        public List<ItemStock> items;


        [JsonConstructor]
        public UpdateStockEvent(List<OrderItem> items)
        {
            List<ItemStock> itemStocks = new List<ItemStock>();
            items.ForEach(item => itemStocks.Add(new ItemStock() { ItemId = item.ItemId, Quantity = item.Quantity }));


            this.items = itemStocks;
        }
    }
}
