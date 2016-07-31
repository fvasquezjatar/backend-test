using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.EntityFramework.Managers.Security;
using IngswDev.Extensions;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace IngswDev.Filters
{
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        public const string COOKIE_AUTHORIZATION = "_Authorization";
        public const string COOKIE_ID = "_AuthorizationId";

        private readonly IUserManager _userManager;
        private static ILogger<AuthorizeFilterAttribute> _logger;

        public AuthorizeFilterAttribute(IUserManager userManager, ILogger<AuthorizeFilterAttribute> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.OnActionExecuting(_userManager, _logger))
            {
                base.OnActionExecuting(context);
            }
        }

        public static void RedirectToLogin(ActionExecutingContext context)
        {
            _logger?.LogInformation("UnAuthorizeException... Redirecting to Login Page...");
            context.HttpContext.Response.Cookies.Delete(COOKIE_AUTHORIZATION);
            context.HttpContext.Response.Cookies.Delete(COOKIE_ID);
            context.Result = new RedirectToActionResult("Login", "Account", new { ReturnUrl = context.HttpContext.Request.GetUri() });
        }
    }
}
