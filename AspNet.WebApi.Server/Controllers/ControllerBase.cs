using AspNet.WebApi.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet.WebApi.Server.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Produces("application/json")]
    public abstract class ControllerBase<T> : ControllerBase

    {
        /// <summary>Global logger</summary>
        protected readonly ILogger<T> Logger;

        /// <inheritdoc />
        protected ControllerBase(ILogger<T> logger)
        {
            Logger = logger;
        }

        /// <inheritdoc />
        public override NotFoundObjectResult NotFound(object value) =>
            base.NotFound(new NotFoundException(value.ToString()));

        /// <inheritdoc />
        public override BadRequestObjectResult BadRequest(object value) =>
            base.BadRequest(new BadRequestException(value.ToString()));

        /// <summary>Return <see cref="OkResult"/> for <paramref name="result"></paramref> true, otherwise return <see cref="UnprocessableEntityObjectResult"/></summary>
        /// <param name="result"></param>
        /// <param name="model"></param>
        /// <returns><see cref="IActionResult"/></returns>
        protected IActionResult SetPropertyResult(bool result, object model) =>
            result ? (IActionResult)Ok(model) : UnprocessableEntity(model);

        /// <summary>Return <see cref="OkResult"/> for <paramref name="result"></paramref> true, otherwise return <see cref="UnprocessableEntityObjectResult"/></summary>
        /// <param name="result"></param>
        /// <returns><see cref="IActionResult"/></returns>
        protected IActionResult DeleteResult(bool result) =>
            result ? (IActionResult)Ok() : UnprocessableEntity();
    }
}
