using System.Threading.Tasks;
using AspNet.WebApi.Server.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AspNet.WebApi.Server.Filters
{
    /// <inheritdoc />
    public class ExceptionAsyncFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<ExceptionAsyncFilter> _logger;

        /// <inheritdoc />
        public ExceptionAsyncFilter(ILogger<ExceptionAsyncFilter> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;

            _logger.LogError(exception, exception.Message);

            context.ExceptionHandled = true;

            var serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var e = exception is ApiException apiException ? apiException : new ApiException(exception.Message, exception);

            context.Result = new JsonResult(e, serializerSettings) { StatusCode = e.StatusCode };

            await Task.CompletedTask;
        }
    }
}
