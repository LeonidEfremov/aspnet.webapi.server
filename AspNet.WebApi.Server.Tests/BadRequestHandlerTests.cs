using System.Net;
using System.Threading.Tasks;
using AspNet.WebApi.Server.Exceptions;
using Xunit;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public partial class ServerTests
    {
        [Fact]
        public async Task BadRequestCustom()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/badrequest?value=1");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var exception = await GetModelAsync<ApiException>(response);

            Assert.Equal("BAD_REQUEST", exception.ReasonCode);
        }
    }
}
