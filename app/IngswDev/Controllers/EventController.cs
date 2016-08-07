using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using IngswDev.EntityFramework.Models.Entities;
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

        [Route("[controller]/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/create")]
        public async Task<IActionResult> Create(EventViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            var newEvent = Mapper.Map<Event>(vm);
            var result = await _eventManager.CreateEventAsync(newEvent);
            if (result > 0)
                return RedirectToAction("Index", "Home");
            ModelState.AddModelError("", "Ops, something went wront trying to create the new event.");
            return View(vm);
        }
    }
}
