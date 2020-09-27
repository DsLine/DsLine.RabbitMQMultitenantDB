using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DsLine.Stock.Infra.Repository;
using DsLine.Stock.Services.Api.Messages.Commands;
using System.Threading.Tasks;

namespace DsLine.Stock.Services.Api.Handlers
{
    public class UpdateStockHandler : IEventHandler<UpdateStockEvent>
    {

        private readonly IItemRepository _itemRepository;

        public UpdateStockHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task HandleAsync(UpdateStockEvent command, ICorrelationContext context)
        {
            _itemRepository.UpdateStock(command.items);
            await Task.CompletedTask;
        }
    }
}