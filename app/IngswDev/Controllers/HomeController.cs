using IngswDev.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IngswDev.Controllers
{

    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {

            return View();
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
