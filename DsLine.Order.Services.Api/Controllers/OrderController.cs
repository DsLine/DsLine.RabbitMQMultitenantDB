using DShop.Common.Messages;
using DShop.Common.RabbitMq;
using DsLine.Orders.Infra.Repository;
using DsLine.Orders.Models.Entities;
using DsLine.Orders.Services.Api.Dto;
using DsLine.Orders.Services.Api.ExternalServices.Stock;
using DsLine.Orders.Services.Api.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using RawRabbit;
using System.Linq;
using DShop.CrossCutting.MultiTenant;

namespace DsLine.Orders.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IStockItemServices _stockItemServices;
        private readonly IBusPublisher _busClient;
        private readonly ITenant _tenant;
        public OrderController(
            IStockItemServices stockItemServices,
            IOrderRepository orderRepository,
            IBusPublisher busClient,
            ITenant tenant
            )
        {
            _orderRepository = orderRepository;
            _stockItemServices = stockItemServices;
            _busClient = busClient;
            _tenant = tenant;
        }


        [HttpPost]
        public async Task<object> PostAsync([FromBody] Order order)
        {
            List<OrderItem> ItemsNotSatisfie = new List<OrderItem>();
            foreach (var item in order.Items)
            {
                ItemStockDTO itemStockDTO = await _stockItemServices.GetItemStockAsync(_tenant.TenantId, item.ItemId);
                if (itemStockDTO.Quantity < item.Quantity)
                {
                    ItemsNotSatisfie.Add(item);
                }
            }

            if (ItemsNotSatisfie.Count > 0)
            {
                return BadRequest("Some items exceed the stock");
            }
            var @updateStockCommand = new UpdateStockEvent(order.Items.ToList());

            //  _busClient.PublishAsync(updateStockCommand, GetContext<UpdateStockEvent>(), "tenant1");

            var gui = Guid.NewGuid();
            _ = _busClient.PublishAsync(@updateStockCommand, CorrelationContext.Create<UpdateStockEvent>(gui, gui, gui, "origen", gui.ToString(), "", "", ""), _tenant.TenantId);

            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
            return Ok("");
        }

        protected ICorrelationContext GetContext<T>(Guid? resourceId = null, string resource = "") where T : IEvent
        {
            if (!string.IsNullOrWhiteSpace(resource))
            {
                resource = $"{resource}/{resourceId}";
            }

            return CorrelationContext.Create<T>(Guid.NewGuid(), Guid.NewGuid(), resourceId ?? Guid.Empty,
               HttpContext.TraceIdentifier, HttpContext.Connection.Id, "",
               Request.Path.ToString(), "", resource);
        }
    }
}
