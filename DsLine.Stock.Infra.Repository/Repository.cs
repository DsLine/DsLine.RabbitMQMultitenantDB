using DsLine.Core.Infra.Repository;

namespace DsLine.Stock.Infra.Repository
{
    public class Repository<TEntity> : BaseRepository<TEntity> where TEntity : class
    {
        public Repository(StockDbContext stockDbContext) : base(stockDbContext)
        {

        }
    }
}
