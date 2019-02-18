using AspNet.WebApi.Server.Controllers;
using AspNet.WebApi.Server.Tests.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet.WebApi.Server.Tests.Controllers
{
    [Route("null")]
    public class NullResponseController : ControllerBase<NullResponseController>
    {
        public NullResponseController(ILogger<NullResponseController> logger) : base(logger) { }

        [HttpGet]
        public IActionResult Get() => Ok(null);

        [HttpPost]
        public IActionResult Post() => Ok(System.Array.Empty<SimpleModel>());
    }
}
