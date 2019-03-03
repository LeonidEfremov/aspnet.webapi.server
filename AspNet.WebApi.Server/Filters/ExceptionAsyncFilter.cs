using AspNet.WebApi.Exceptions;
using AspNet.WebApi.Exceptions.Models;
using AspNet.WebApi.Exceptions.Interfaces;
using AspNet.WebApi.Exceptions.Mapper;
using AspNet.WebApi.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AspNet.WebApi.Server.Filters
{
    /// <inheritdoc />
    public class ExceptionAsyncFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<ExceptionAsyncFilter> _logger;
        private readonly IExceptionMapper _exceptionMapper;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        /// <inheritdoc />
        public ExceptionAsyncFilter(IOptions<MvcJsonOptions> jsonOptions, ILogger<ExceptionAsyncFilter> logger, IExceptionMapper exceptionMapper = null)
        {
            _jsonSerializerSettings = jsonOptions.Value.SerializerSettings;
            _logger = logger;
            _exceptionMapper = exceptionMapper;
        }

        /// <inheritdoc />
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var contextException = context.Exception;
            var apiException = GetApiException(contextException);
            var apiExceptionModel = new ApiExceptionModel(apiException);

            _logger.LogError(contextException, contextException.Message);

            context.ExceptionHandled = true;
            context.Result = new JsonResult(apiExceptionModel, _jsonSerializerSettings);;
            context.HttpContext.Response.StatusCode = apiExceptionModel.StatusCode;

            await Task.CompletedTask;
        }

        private ApiException GetApiException(Exception exception)
        {
            return exception is ApiException e ? e : new ApiException(exception.Message, exception);
        }
    }
}