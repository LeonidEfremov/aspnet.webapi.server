using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using AspNet.WebApi.Server.Tests.Models;
using Xunit;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public partial class ServerTests
    {
        [Fact]
        public async Task GetSomeData()
        {
            var data = "some data";
            var response = await Client.SetDefaultHeaders().GetAsync(string.Format(CultureInfo.InvariantCulture, "/dataprovider?param={0}", data));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var model = await GetModelAsync<SimpleModel>(response);

            Assert.Equal($"connectionString: {data}", model.Title);
        }
    }
}