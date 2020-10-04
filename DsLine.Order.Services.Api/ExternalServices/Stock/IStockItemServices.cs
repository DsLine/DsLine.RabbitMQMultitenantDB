using DsLine.Orders.Services.Api.Dto;
using RestEase;
using System;
using System.Threading.Tasks;

namespace DsLine.Orders.Services.Api.ExternalServices.Stock
{
    public interface IStockItemServices
    {
        [AllowAnyStatusCode]
        [Get("/api/item/{id}")]
        Task<ItemStockDTO> GetItemStockAsync([Header("Authorization")] string authorization, [Path] Guid id);
    }
}
