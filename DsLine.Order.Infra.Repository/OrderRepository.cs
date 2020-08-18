using DsLine.Orders.Models.Entities;

namespace DsLine.Orders.Infra.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext orderDbContext):base(orderDbContext)
        {

        }
    }
}
