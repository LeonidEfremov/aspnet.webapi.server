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
        public async Task ResponseCompressionHeaders()
        {
            var client = Client.SetDefaultHeaders();

            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");

            var response = await client.GetAsync("/");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.Content.Headers.Contains("Content-Encoding"));
            Assert.Equal("gzip", response.Content.Headers.GetValues("Content-Encoding").First());
        }
    }
}
