using DsLine.Core.Infra.Repository;

namespace DsLine.Orders.Infra.Repository
{
    public class Repository<TEntity> : BaseRepository<TEntity> where TEntity : class
    {
        public Repository(OrderDbContext orderDbContext) : base(orderDbContext)
        {

        }
    }
}
