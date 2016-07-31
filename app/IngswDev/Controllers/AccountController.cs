using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.Extensions;
using IngswDev.Filters;
using IngswDev.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IngswDev.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;

        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Login([FromQuery] string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(TransactionalFilterAttribute))]
        public async Task<IActionResult> Register(RegisterViewModel register, [FromQuery] string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            if (!ModelState.IsValid)
                return View(register);
            var userId = await _userManager.CreateAsync(register);
            if (string.IsNullOrEmpty(userId))
                return View(register);
            var token = await _userManager.AllowAccess(userId);
            Response.Authorize(userId, token.AccessToken);
            if (string.IsNullOrEmpty(ReturnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(ReturnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(TransactionalFilterAttribute))]
        public async Task<IActionResult> Login(LoginViewModel request, [FromQuery] string ReturnUrl)
        {
            if (!ModelState.IsValid)
                return View(request);
            var userId = await _userManager.SignInAsync(request);
            if (string.IsNullOrEmpty(userId))
                return View(request);
            var token = await _userManager.AllowAccess(userId);
            Response.Authorize(userId, token.AccessToken);
            if (string.IsNullOrEmpty(ReturnUrl))
                return RedirectToAction("Index", "Home");
            return Redirect(ReturnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            return Response.RevokeAccess();
        }
    }
}
