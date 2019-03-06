using AspNet.WebApi.Exceptions.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

            var exception = await GetModelAsync<ApiExceptionModel>(response);

            Assert.Equal("BAD_REQUEST", exception.ReasonCode);
        }

        [Fact(Skip = "NTBD")]
        public async Task BadRequestBinding()
        {
            var model = new StringContent("{id:\"1.2\",title:1234567,flag:null}");
            model.Headers.ContentType.MediaType = "application/json";
            var response = await Client.SetDefaultHeaders().PostAsync("/badrequest", model);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var exception = await GetModelAsync<ApiExceptionModel>(response);

            Assert.Equal("BAD_REQUEST", exception.Message);
        }
    }
}
