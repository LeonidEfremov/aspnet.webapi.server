using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNet.WebApi.Server.Filters
{
    /// <summary>Server BadRequest response.</summary>
    public class BadRequestAsyncFilter : IAsyncActionFilter
    {
        /// <inheritdoc />
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next();
            }
            else
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
