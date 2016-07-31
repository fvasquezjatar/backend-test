using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IngswDev.Filters
{
    public class AllowAnonymousAttribute : ActionFilterAttribute, IAllowAnonymousFilter
    {
        
    }
}
