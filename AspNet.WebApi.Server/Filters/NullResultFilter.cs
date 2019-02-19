using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNet.WebApi.Server.Filters
{
    /// <inheritdoc />
    public class NullResultFilter : IResultFilter
    {
        /// <inheritdoc />
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult result && result.Value == null)
            {
                context.Result = new NotFoundResult();
            }
        }

        /// <inheritdoc />
        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Pass thru action
        }
    }
}
