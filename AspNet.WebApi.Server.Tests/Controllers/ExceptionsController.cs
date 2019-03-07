using AspNet.WebApi.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace AspNet.WebApi.Server.Tests.Controllers
{
    [Route("exceptions")]
    public class ExceptionsController : ControllerBase<ExceptionsController>
    {
        [HttpGet("unhandled")]
        public IActionResult UnhandledException() =>
            throw new Exception("Common Exception", new StackOverflowException("Stack Overflow Exception"));

        [HttpGet("unhandled/api")]
        public IActionResult UnhandledApiException() =>
            throw new ApiException((int)HttpStatusCode.GatewayTimeout, "GATEWAY_TIMEOUT", "Gateway Timeout");

        [HttpGet("unhandled/api/badrequest")]
        public IActionResult UnhandledBadRequestApiException() =>
            throw new BadRequestException();

        [HttpGet("unhandled/api/nullreference")]
        public IActionResult UnhandledNullReferenceException() =>
            throw new NullReferenceException();

        [HttpGet("unhandled/content")]
        public IActionResult UnhandledApiExceptionWithContent() =>
            throw new ApiException(
                (int)HttpStatusCode.InternalServerError,
                "AGGREGATE_EXCEPTION",
                "Reset Content",
                new AggregateException(
                    new ArgumentException("First null exception"),
                    new ArgumentException("Second null exception")));

        [HttpGet("handled")]
        public IActionResult HandledException()
        {
            try
            {
                throw new Exception();
            }
            catch
            {
                // ignored
            }

            return Ok();
        }

        public ExceptionsController(ILogger<ExceptionsController> logger) : base(logger) { }
    }
}