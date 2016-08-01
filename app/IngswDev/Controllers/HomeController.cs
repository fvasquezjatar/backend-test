using System.Threading.Tasks;
using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.Filters;
using IngswDev.Models;
using Microsoft.AspNetCore.Mvc;

namespace IngswDev.Controllers
{

    public class HomeController : Controller
    {
        private readonly IEventManager _eventManager;

        public HomeController(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var events = await _eventManager.EventsAsync(new PagingViewModel(0, 4));
            return View(events);
        }
        [AllowAnonymous]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
