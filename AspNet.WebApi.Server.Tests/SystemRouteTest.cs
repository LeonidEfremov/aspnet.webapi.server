using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public partial class ServerTests
    {
        [Theory]
        [InlineData("/")]
        [InlineData("/swagger/index.html")]
        [InlineData("/swagger/v1/swagger.json")]
        public async Task SystemRoutes(string url)
        {
            var response = await Client.GetAsync(url);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();

            Assert.NotEmpty(body);
        }
    }
}
