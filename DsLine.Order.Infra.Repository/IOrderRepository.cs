using DsLine.Core.Infra.Repository;
using DsLine.Orders.Models.Entities;

namespace DsLine.Orders.Infra.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }
}
