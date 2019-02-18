using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public partial class ServerTests
    {
        [Fact]
        public async Task NullResponse()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/null");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task OkResponse()
        {
            var response = await Client.SetDefaultHeaders().PostAsync("/null", null);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
