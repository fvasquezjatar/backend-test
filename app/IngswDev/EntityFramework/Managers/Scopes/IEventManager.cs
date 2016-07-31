using System.Collections.Generic;
using System.Threading.Tasks;
using IngswDev.EntityFramework.Models.Entities;
using IngswDev.Models;

namespace IngswDev.EntityFramework.Managers.Scopes
{
    public interface IEventManager
    {
        Task<List<Event>> EventsAsync(PagingViewModel paging);
        Task<List<Event>> HighlightsAsync(PagingViewModel paging);
        Task<int> CreateEventAsync(Event newEvent);
        Task<Event> FindAsync(long id);
    }
}
