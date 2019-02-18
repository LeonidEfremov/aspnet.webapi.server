using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public partial class ServerTests
    {
        [Fact]
        public async Task CorsHeaders()
        {
            var client = Client.SetDefaultHeaders();

            client.DefaultRequestHeaders.Add("Origin", _origin);

            var response = await client.GetAsync("/dataprovider?param=0");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.Headers.Contains("Access-Control-Allow-Origin"));
            Assert.Equal(_origin, response.Headers.GetValues("Access-Control-Allow-Origin").First());
            Assert.False(response.Headers.Contains("Access-Control-Allow-Credentials"));
        }
    }
}
