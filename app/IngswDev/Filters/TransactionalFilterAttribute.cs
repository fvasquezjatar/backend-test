using IngswDev.EntityFramework;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace IngswDev.Filters
{
    public class TransactionalFilterAttribute : ActionFilterAttribute
    {
        private readonly IngswDevDB _db;

        public TransactionalFilterAttribute(IngswDevDB db)
        {
            _db = db;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                var executedContext = await next();
                if (executedContext.Exception != null)
                    transaction.Rollback();
                else
                    transaction.Commit();
            }
        }
    }
}
