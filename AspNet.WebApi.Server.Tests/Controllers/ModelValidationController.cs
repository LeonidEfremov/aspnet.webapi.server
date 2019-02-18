using AspNet.WebApi.Server.Attributes;
using AspNet.WebApi.Server.Controllers;
using AspNet.WebApi.Server.Models;
using AspNet.WebApi.Server.Tests.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet.WebApi.Server.Tests.Controllers
{
    [Route("model")]
    public class ModelValidationController : ControllerBase<ModelValidationController>
    {
        public ModelValidationController(ILogger<ModelValidationController> logger) : base(logger) { }

        [HttpGet]
        public IActionResult Get(int param1, bool param2) => Ok(SuccessModel.Default);

        [HttpPost]
        public SimpleModel Post([FromBody, Required] SimpleModel model) => model;

        [IgnoreModelValidation]
        [HttpGet("ignore/validation")]
        public IActionResult IgnoreValidation(int param) => Ok(param);
    }
}
