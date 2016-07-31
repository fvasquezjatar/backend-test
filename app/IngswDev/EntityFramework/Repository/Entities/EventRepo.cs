using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IngswDev.EntityFramework.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IngswDev.EntityFramework.Repository.Entities
{
    public class EventRepo : Repository<Event>
    {
        public EventRepo(IngswDevDB db, ILogger<Repository<Event>> logger)
            : base(db, logger)
        {
        }

        public Task<Event> Find(long id)
        {
            return _db.Events.FirstOrDefaultAsync(key => key.Id.Equals(id));
        }

        public Task<List<Event>> EventsAsync(int? page, int? pageSize)
        {
            page = page ?? 0;
            pageSize = pageSize ?? DEFAULT_PAGE_SIZE;
            var query = from e in _db.Events.Include(p => p.TargetDates)
                        join dates in _db.TargetDates on e.Id equals dates.EventId
                        orderby dates.TargetDate descending
                        select e;
            return query.Skip((int)(page * pageSize)).Take((int)pageSize).ToListAsync();
        }

        public Task<List<Event>> HighlightsAsync(int? page, int? pageSize)
        {
            page = page ?? 0;
            pageSize = pageSize ?? DEFAULT_PAGE_SIZE;
            var query = from e in _db.Events.Include(p => p.TargetDates)
                        join dates in _db.TargetDates on e.Id equals dates.EventId
                        where e.Highlight
                        orderby dates.TargetDate descending
                        select e;
            return query.Skip((int)(page * pageSize)).Take((int)pageSize).ToListAsync();
        }
    }
}
