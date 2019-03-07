using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
            base.NotFound(new Exception(value.ToString()));

        /// <inheritdoc />
        public override BadRequestObjectResult BadRequest(object error) =>
            base.BadRequest(new Exception(error.ToString()));
    }
}
