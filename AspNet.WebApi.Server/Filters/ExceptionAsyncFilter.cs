using AspNet.WebApi.Common.Exceptions;
using AspNet.WebApi.Server.Models;
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
            var contextException = context.Exception;

            _logger.LogError(contextException, contextException.Message);

            context.ExceptionHandled = true;

            var apiException = contextException is ApiException e ? e : new ApiException(contextException.Message, contextException);
            var apiExceptionModel = new ApiExceptionModel(apiException);
            var result = new JsonResult(apiExceptionModel, _jsonSerializerSettings);

            context.Result = result;
            context.HttpContext.Response.StatusCode = apiExceptionModel.StatusCode;

            await Task.CompletedTask;
        }
    }
}