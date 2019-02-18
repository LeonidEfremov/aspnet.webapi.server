using AspNet.WebApi.Server.Controllers;
using AspNet.WebApi.Server.Tests.Models;
using AspNet.WebApi.Server.Tests.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet.WebApi.Server.Tests.Controllers
{
    [Route("dataprovider")]
    public class DataProviderController : ControllerBase<DataProviderController>
    {
        private readonly ILogger _logger;
        private readonly IDataProvider _dataProvider;

        public DataProviderController(IDataProvider dataProvider, ILogger<DataProviderController> logger) : base(logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string param)
        {
            var data = _dataProvider.GetSomeData(param);

            _logger.LogInformation(param);

            return Ok(new SimpleModel { Id = 0, Flag = true, Title = data });
        }
    }
}
