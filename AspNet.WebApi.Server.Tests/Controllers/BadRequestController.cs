using AspNet.WebApi.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet.WebApi.Server.Tests.Controllers
{
    [Route("badrequest")]
    public class BadRequestController : ControllerBase<BadRequestController>
    {
        public BadRequestController(ILogger<BadRequestController> logger) : base(logger) { }

        [HttpGet("")]
        public IActionResult Get([FromQuery] string value) => BadRequest(value);
    }
}
