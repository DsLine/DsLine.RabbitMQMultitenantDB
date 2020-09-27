using DShop.Common.Messages;
using DsLine.Stock.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DsLine.Stock.Services.Api.Messages.Commands
{
    public class UpdateStockEvent : IEvent
    {
        public List<ItemStock> items { get; set; }

        [JsonConstructor]
        public UpdateStockEvent(List<ItemStock> itemStocks)
        {
            items = itemStocks;
        }
    }
}
