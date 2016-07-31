using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.EntityFramework.Models.Entities;
using IngswDev.EntityFramework.Repository.Entities;
using IngswDev.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IngswDev.EntityFramework.Managers.Entities
{
    public class EventManager : IEventManager
    {
        private readonly IUserManager _userManager;
        private readonly EventDateRepo _dateRepo;
        private readonly EventRepo _eventRepo;

        public EventManager(EventRepo eventRepo, EventDateRepo dateRepo, IUserManager userManager)
        {
            _eventRepo = eventRepo;
            _dateRepo = dateRepo;
            _userManager = userManager;
        }

        public Task<List<Event>> EventsAsync(PagingViewModel paging)
        {
            return _eventRepo.EventsAsync(paging.Page, paging.PageSize);
        }

        public Task<List<Event>> HighlightsAsync(PagingViewModel paging)
        {
            return _eventRepo.HighlightsAsync(paging.Page, paging.PageSize);
        }

        public Task<int> CreateEventAsync(Event newEvent)
        {
            _eventRepo.Add(newEvent);
            return _eventRepo.SaveAsync();
        }

        public Task<Event> FindAsync(long id)
        {
            return _eventRepo.Find(id);
        }
    }
}
