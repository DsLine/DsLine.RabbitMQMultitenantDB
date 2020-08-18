using DsLine.Orders.Infra.Repository;
using DsLine.Orders.Models.Entities;
using DsLine.Orders.Services.Api.Dto;
using DsLine.Orders.Services.Api.ExternalServices.Stock;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DsLine.Orders.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IStockItemServices _stockItemServices;
        public OrderController(IStockItemServices stockItemServices, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _stockItemServices = stockItemServices;
        }


        [HttpPost]
        public async Task<ActionResult<object>> PostAsync([FromBody] Order order)
        {
            List<OrderItem> ItemsNotSatisfie = new List<OrderItem>();
            foreach (var item in order.Items)
            {
                ItemStockDTO itemStockDTO = await _stockItemServices.GetItemStockAsync(item.Id);
                if (itemStockDTO.Quantity < item.Quantity)
                {
                    ItemsNotSatisfie.Add(item);
                }
            }

            if (ItemsNotSatisfie.Count > 0)
            {
                return BadRequest("Some items exceed the stock");
            }

            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
            return Ok("");
        }
    }
}
