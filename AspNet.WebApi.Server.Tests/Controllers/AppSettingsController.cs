using AspNet.WebApi.Server.Controllers;
using AspNet.WebApi.Server.Tests.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNet.WebApi.Server.Tests.Controllers
{
    [Route("appsettings")]
    public class AppSettingsController : ControllerBase<AppSettingsController>
    {
        private readonly IConfiguration _configuration;

        public AppSettingsController(IConfiguration configuration, ILogger<AppSettingsController> logger) : base(logger)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get() => Ok(new AppSettingsModel { Value = _configuration["parameter"] });
    }
}