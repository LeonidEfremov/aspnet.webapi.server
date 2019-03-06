//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System.Threading.Tasks;
//using AspNet.WebApi.Exceptions;

//namespace AspNet.WebApi.Server.Filters
//{
//    /// <summary>Server BadRequest response.</summary>
//    public class BadRequestAsyncFilter : IAsyncActionFilter
//    {
//        /// <inheritdoc />
//        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//        {
//            if (context.ModelState.IsValid)
//            {
//                await next();
//            }
//            else
//            {
//                throw new BadRequestException();
//                //context.Result = new BadRequestObjectResult(context.ModelState);
//            }
//        }
//    }
//}
