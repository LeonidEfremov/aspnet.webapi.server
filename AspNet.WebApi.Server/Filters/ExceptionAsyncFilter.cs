using AspNet.WebApi.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AspNet.WebApi.Server.Filters
{
    /// <inheritdoc />
    public class ExceptionAsyncFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<ExceptionAsyncFilter> _logger;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        /// <inheritdoc />
        public ExceptionAsyncFilter(IOptions<MvcJsonOptions> jsonOptions, ILogger<ExceptionAsyncFilter> logger)
        {
            _jsonSerializerSettings = jsonOptions.Value.SerializerSettings;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;

            _logger.LogError(exception, exception.Message);

            context.ExceptionHandled = true;

            var e = exception is ApiException apiException ? apiException : new ApiException(exception.Message, exception);

            context.Result = new JsonResult(e, _jsonSerializerSettings) { StatusCode = e.StatusCode };
            context.HttpContext.Response.StatusCode = e.StatusCode;

            await Task.CompletedTask;
        }
    }
}
