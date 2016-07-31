using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace IngswDev.EntityFramework.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected const int DEFAULT_PAGE_SIZE = 20;

        protected readonly IngswDevDB _db;
        protected readonly ILogger<Repository<TEntity>> _logger;

        protected Repository(IngswDevDB db, ILogger<Repository<TEntity>> logger)
        {
            _db = db;
            _logger = logger;
        }

        public virtual void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            _db.Entry(entity).State = EntityState.Added;
            _logger?.LogInformation($"New instance pf {typeof(TEntity).Name} was added");
        }

        public virtual void Delete(TEntity entity)
        {
            _db.Set<TEntity>().Attach(entity);
            _db.Entry(entity).State = EntityState.Deleted;
            _logger?.LogInformation($"New instance pf {typeof(TEntity).Name} was marked to delete");
        }

        public virtual Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();
        }

        public virtual Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public virtual Task<List<TEntity>> ToListAsync()
        {
            return _db.Set<TEntity>().ToListAsync();
        }

        public virtual Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> predicate, int? page, int? pageSize)
        {
            pageSize = pageSize ?? DEFAULT_PAGE_SIZE;
            page = page ?? 0;
            return _db.Set<TEntity>().Where(predicate).Skip((int)(page * pageSize))
                .Take((int)pageSize).ToListAsync();
        }

        public virtual Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate)
                .ToListAsync();
        }
        public virtual void Update(TEntity entity)
        {
            _db.Set<TEntity>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _logger?.LogInformation($"New instance pf {typeof(TEntity).Name} was marked to update");
        }

    }
}
