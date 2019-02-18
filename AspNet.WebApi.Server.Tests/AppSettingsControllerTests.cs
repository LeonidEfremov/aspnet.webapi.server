using System.Net;
using System.Threading.Tasks;
using AspNet.WebApi.Server.Tests.Models;
using Xunit;
using Xunit.Asserts.Compare;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public partial class ServerTests
    {
        [Fact]
        public async Task AppSettingsResponse()
        {
            var expected = new AppSettingsModel { Value = "value" };
            var response = await Client.SetDefaultHeaders().GetAsync("/appsettings");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var actual = await GetModelAsync<AppSettingsModel>(response);

            DeepAssert.Equal(expected, actual);
        }
    }
}
