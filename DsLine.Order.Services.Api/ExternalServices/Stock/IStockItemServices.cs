using DsLine.Orders.Models.Entities;
using DsLine.Orders.Services.Api.Dto;
using RestEase;
using System;
using System.Threading.Tasks;

namespace DsLine.Orders.Services.Api.ExternalServices.Stock
{
    public interface IStockItemServices
    {
        [AllowAnyStatusCode]
        [Get("/api/itemStock/{id}")]
        Task<ItemStockDTO> GetItemStockAsync([Path] Guid id);
    }
}
