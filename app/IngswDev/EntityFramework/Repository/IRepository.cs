using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IngswDev.EntityFramework.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> ToListAsync();

        Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveAsync();
    }
}
