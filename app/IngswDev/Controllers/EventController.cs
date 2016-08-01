using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IngswDev.Models;

namespace IngswDev.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventManager _eventManager;

        public EventController(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        [AllowAnonymous]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Index(long id)
        {
            var _event = await _eventManager.FindAsync(id);
            if (_event == null)
                return NotFound();
            return View(_event);
        }
    }
}
