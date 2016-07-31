using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.EntityFramework.Managers.Security;
using IngswDev.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace IngswDev.Filters
{
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        public const string COOKIE_AUTHORIZATION = "_Authorization";
        public const string COOKIE_ID = "_AuthorizationId";

        private readonly IUserManager _userManager;

        public AuthorizeFilterAttribute()
        {
            _userManager = UserManager.GetInstance();
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Filters.All(f => f.GetType() != typeof(AllowAnonymousFilter)))
            {
                if (!context.HttpContext.Request.Cookies.Any(c => c.Key.Equals(COOKIE_AUTHORIZATION))
                    || !context.HttpContext.Request.Cookies.Any(c => c.Key.Equals(COOKIE_ID)))
                {
                    RedirectToLogin(context);
                    return;
                }
                var id = context.HttpContext.Request.Cookies[COOKIE_ID].DecodeFromBase64();
                var token = context.HttpContext.Request.Cookies[COOKIE_AUTHORIZATION].DecodeFromBase64();
                if (!_userManager.Authenticate(id, token))
                {
                    RedirectToLogin(context);
                    return;
                }
            }
            base.OnActionExecuting(context);
        }

        private static void RedirectToLogin(ActionExecutingContext context)
        {
            context.HttpContext.Response.Cookies.Delete(COOKIE_AUTHORIZATION);
            context.HttpContext.Response.Cookies.Delete(COOKIE_ID);
            context.Result = new RedirectToActionResult("Login", "Account", null);
        }
    }
}
