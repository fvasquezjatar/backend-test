using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.EntityFramework.Managers.Security;
using IngswDev.EntityFramework.Models.Security;
using IngswDev.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IngswDev.Extensions
{
    public static class RequestExtension
    {
        public static bool IsAuthenticated(this HttpRequest requestContext)
        {
            if (!requestContext.HttpContext.Request.Cookies.Any(c => c.Key.Equals(AuthorizeFilterAttribute.COOKIE_AUTHORIZATION))
                    || !requestContext.HttpContext.Request.Cookies.Any(c => c.Key.Equals(AuthorizeFilterAttribute.COOKIE_ID)))
            {
                return false;
            }
            var id = requestContext.HttpContext.Request.Cookies[AuthorizeFilterAttribute.COOKIE_ID].DecodeFromBase64();
            var token = requestContext.HttpContext.Request.Cookies[AuthorizeFilterAttribute.COOKIE_AUTHORIZATION].DecodeFromBase64();
            return UserManager.GetInstance().Authenticate(id, token);
        }

        public static string GetUserId(this HttpRequest requestContext)
        {
            if (!requestContext.HttpContext.Request.Cookies.Any(c => c.Key.Equals(AuthorizeFilterAttribute.COOKIE_AUTHORIZATION))
                    || !requestContext.HttpContext.Request.Cookies.Any(c => c.Key.Equals(AuthorizeFilterAttribute.COOKIE_ID)))
            {
                return "";
            }
            return requestContext.HttpContext.Request.Cookies[AuthorizeFilterAttribute.COOKIE_ID].DecodeFromBase64();
        }

        public static Task<User> GetUserAsync(this HttpRequest requestContext)
        {
            if (!requestContext.HttpContext.Request.Cookies.Any(c => c.Key.Equals(AuthorizeFilterAttribute.COOKIE_AUTHORIZATION))
                    || !requestContext.HttpContext.Request.Cookies.Any(c => c.Key.Equals(AuthorizeFilterAttribute.COOKIE_ID)))
            {
                return null;
            }
            var userId = requestContext.HttpContext.Request.Cookies[AuthorizeFilterAttribute.COOKIE_ID].DecodeFromBase64();
            var userManager = UserManager.GetInstance();
            return userManager.FindByIdAsync(userId);
        }

        public static bool OnActionExecuting(this ActionExecutingContext context, IUserManager userManager,
            ILogger<AuthorizeFilterAttribute> logger)
        {
            if (context.Filters.All(f => f.GetType() != typeof(AllowAnonymousAttribute)))
            {
                if (!context.HttpContext.Request.Cookies.Any(c => c.Key.Equals(AuthorizeFilterAttribute.COOKIE_AUTHORIZATION))
                    || !context.HttpContext.Request.Cookies.Any(c => c.Key.Equals(AuthorizeFilterAttribute.COOKIE_ID)))
                {
                    AuthorizeFilterAttribute.RedirectToLogin(context);
                    return true;
                }
                var id = context.HttpContext.Request.Cookies[AuthorizeFilterAttribute.COOKIE_ID].DecodeFromBase64();
                var token = context.HttpContext.Request.Cookies[AuthorizeFilterAttribute.COOKIE_AUTHORIZATION].DecodeFromBase64();
                if (!userManager.Authenticate(id, token))
                {
                    AuthorizeFilterAttribute.RedirectToLogin(context);
                    return true;
                }
                logger?.LogInformation($"{token} is valid.");
            }
            else
                logger?.LogInformation($"{context.Controller} has AllowAnonymousAttribute");
            return false;
        }

        public static void Authorize(this HttpResponse responseContext, string userId, string accessToken)
        {
            var options = new CookieOptions()
            {
                //Domain = $"{responseContext.HttpContext.Request.Host}",
                Path = "/",
                Expires = DateTime.Now.AddMinutes(30)
            };
            responseContext.Cookies.Append(AuthorizeFilterAttribute.COOKIE_ID, userId.EncodeBase64(), options);
            responseContext.Cookies.Append(AuthorizeFilterAttribute.COOKIE_AUTHORIZATION, accessToken.EncodeBase64(), options);
        }

        public static IActionResult RevokeAccess(this HttpResponse responseContext)
        {
            responseContext.Cookies.Delete(AuthorizeFilterAttribute.COOKIE_ID);
            responseContext.Cookies.Delete(AuthorizeFilterAttribute.COOKIE_AUTHORIZATION);
            return new RedirectToActionResult("Index", "Home", null);
        }
    }
}
