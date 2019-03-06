using AspNet.WebApi.Server.Controllers;
using AspNet.WebApi.Server.Example.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet.WebApi.Server.Example.Controllers
{
    /// <summary>Example controller.</summary>
    [ApiController]
    [Route("example")]
    public class ExampleController : ControllerBase<ExampleController>
    {
        /// <inheritdoc />
        public ExampleController(ILogger<ExampleController> logger) : base(logger) { }

        /// <summary>Simple GET operation.</summary>
        /// <param name="param">Parameter.</param>
        /// <response code="200">Successful operation</response>
        [HttpGet("{param}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Get([FromRoute]string param) => Ok(param);

        /// <summary>Simple POST operation.</summary>
        /// <param name="model"><see cref="ExampleModel"/>.</param>
        [HttpPost]
        [ProducesResponseType(typeof(ExampleModel), StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] ExampleModel model) => Ok(model);

        /// <summary>Simple operation with ArgumentException.</summary>
        [HttpGet("exceptions")]
        public IActionResult Get()=> throw new System.ArgumentException();
    }
}
