using System;
using AspNet.WebApi.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet.WebApi.Server.Tests.Controllers
{
    [Route("header")]
    public class HeaderController : ControllerBase<HeaderController>
    {
        public HeaderController(ILogger<HeaderController> logger) : base(logger) { }

        [HttpGet("")]
        public IActionResult Get([FromHeader] Guid value) => Ok(value);
    }
}
