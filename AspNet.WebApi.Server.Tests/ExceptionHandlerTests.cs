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
        public async Task HandledException()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/handled");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UnhandledException()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

            var exception = await GetModelAsync<ApiException>(response);

            Assert.Equal("EXCEPTION", exception.ReasonCode);
        }

        [Fact]
        public async Task UnhandledApiException()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled/api");

            Assert.Equal(HttpStatusCode.GatewayTimeout, response.StatusCode);

            var exception = await GetModelAsync<ApiException>(response);

            Assert.Equal("GATEWAY_TIMEOUT", exception.ReasonCode);
        }

        [Fact]
        public async Task UnhandledBadRequestApiException()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled/api/badrequest");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var exception = await GetModelAsync<ApiException>(response);

            Assert.Equal("BAD_REQUEST", exception.ReasonCode);
        }

        [Fact]
        public async Task UnhandledApiExceptionWithContent()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled/content");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

            var exception = await GetModelAsync<ApiException>(response);

            Assert.Equal("AGGREGATE_EXCEPTION", exception.ReasonCode);
        }
    }
}
