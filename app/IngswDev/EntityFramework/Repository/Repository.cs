using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IngswDev.EntityFramework.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly IngswDevDB _db;
        protected readonly ILogger<Repository<TEntity>> _logger;

        protected Repository(IngswDevDB db, ILogger<Repository<TEntity>> logger)
        {
            _db = db;
            _logger = logger;
        }

        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            _db.Entry(entity).State = EntityState.Added;
            _logger.LogInformation($"New instance pf {typeof(TEntity).Name} was added");
        }

        public void Delete(TEntity entity)
        {
            _db.Set<TEntity>().Attach(entity);
            _db.Entry(entity).State = EntityState.Deleted;
            _logger.LogInformation($"New instance pf {typeof(TEntity).Name} was marked to delete");
        }

        public Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();
        }

        public Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public Task<List<TEntity>> ToListAsync()
        {
            return _db.Set<TEntity>().ToListAsync();
        }

        public Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate)
                .ToListAsync();
        }
        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _logger.LogInformation($"New instance pf {typeof(TEntity).Name} was marked to update");
        }

    }
}
