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
    }
}
