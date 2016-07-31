using IngswDev.EntityFramework.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IngswDev.EntityFramework.Repository.Entities
{
    public class EventDateRepo : Repository<EventDate>
    {
        public EventDateRepo(IngswDevDB db, ILogger<Repository<EventDate>> logger)
            : base(db, logger)
        {

        }

        public Task<EventDate> Find(long id)
        {
            return _db.TargetDates.FirstOrDefaultAsync(key => key.Id.Equals(id));
        }
    }
}
