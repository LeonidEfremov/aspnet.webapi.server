using AspNet.WebApi.Exceptions;
using AspNet.WebApi.Exceptions.Models;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Xunit;
using Xunit.Asserts.Compare;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public partial class ServerTests
    {
        [Fact]
        public void Serialization()
        {
            ApiException exception;

            try
            {
                throw new ApiException();
            }
            catch (ApiException ex)
            {
                exception = ex;
            }

            var formatter = new BinaryFormatter();
            ApiException actual;

            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, exception);
                ms.Seek(0, SeekOrigin.Begin);
                actual = (ApiException)formatter.Deserialize(ms);
            }

            DeepAssert.Equal(exception, actual, "StackTrace", "TargetSite");
        }


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

            var exception = await GetModelAsync<ApiExceptionModel>(response);

            Assert.Equal("EXCEPTION", exception.ReasonCode);
        }

        [Fact]
        public async Task UnhandledApiException()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled/api");

            Assert.Equal(HttpStatusCode.GatewayTimeout, response.StatusCode);

            var exception = await GetModelAsync<ApiExceptionModel>(response);

            Assert.Equal("GATEWAY_TIMEOUT", exception.ReasonCode);
        }

        [Fact]
        public async Task UnhandledBadRequestApiException()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled/api/badrequest");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var exception = await GetModelAsync<ApiExceptionModel>(response);

            Assert.Equal("BAD_REQUEST", exception.ReasonCode);
        }

        [Fact]
        public async Task UnhandledApiExceptionWithContent()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled/content");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

            var exception = await GetModelAsync<ApiExceptionModel>(response);

            Assert.Equal("AGGREGATE_EXCEPTION", exception.ReasonCode);
        }
    }
}
