using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.EntityFramework.Repository.Entities;

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
    }
}
