using System;
using System.Linq;

namespace DsLine.Core.Infra.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);

        IQueryable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(Guid id);

        int SaveChanges();

        void Dispose();

    }
}
