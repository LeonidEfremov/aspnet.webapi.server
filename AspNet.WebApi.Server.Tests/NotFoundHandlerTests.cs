using System.Net;
using System.Threading.Tasks;
using AspNet.WebApi.Server.Exceptions;
using Newtonsoft.Json;
using Xunit;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public partial class ServerTests
    {
        [Fact]
        public async Task NotFoundExists()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/notfound/exists");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();

            Assert.Empty(body);
        }

        [Fact]
        public async Task NotFoundNotExists()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/notfound/notexists");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();

            Assert.Empty(body);
        }

        [Fact]
        public async Task NotFoundCustom()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/notfound?value=1");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();
            var exception = JsonConvert.DeserializeObject<ApiException>(body);

            Assert.Equal("NOT_FOUND", exception.ReasonCode);
        }
    }
}
