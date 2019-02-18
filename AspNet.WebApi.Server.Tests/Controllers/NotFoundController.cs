using AspNet.WebApi.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet.WebApi.Server.Tests.Controllers
{
    [Route("notfound")]
    public class NotFoundController : ControllerBase<NotFoundController>
    {
        public NotFoundController(ILogger<NotFoundController> logger) : base(logger) { }

        [HttpGet("")]
        public IActionResult Get([FromQuery] string value) => NotFound(value);

        [HttpGet("exists")]
        public IActionResult Get() => Ok();
    }
}
