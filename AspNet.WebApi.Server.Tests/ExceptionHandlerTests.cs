using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Fact(Skip = "exception")]
        public void Serialization()
        {
            Exception exception;

            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            var formatter = new BinaryFormatter();
            Exception actual;

            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, exception);
                ms.Seek(0, SeekOrigin.Begin);
                actual = (Exception)formatter.Deserialize(ms);
            }

            DeepAssert.Equal(exception, actual, "StackTrace", "TargetSite");
        }


        [Fact(Skip="exception handling")]
        public async Task HandledException()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/handled");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(Skip="exception handling")]
        public async Task UnhandledException()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

            var exception = await GetModelAsync<ProblemDetails>(response);

            Assert.Equal(StatusCodes.Status400BadRequest, exception.Status);
        }

        [Fact(Skip="exception handling")]
        public async Task UnhandledApiException()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled/api");

            Assert.Equal(HttpStatusCode.GatewayTimeout, response.StatusCode);

            var exception = await GetModelAsync<ProblemDetails>(response);

            Assert.Equal(StatusCodes.Status502BadGateway, exception.Status);
        }

        [Fact(Skip="exception handling")]
        public async Task UnhandledBadRequestApiException()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled/api/badrequest");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var exception = await GetModelAsync<ProblemDetails>(response);

            Assert.Equal(StatusCodes.Status400BadRequest, exception.Status);
        }

        [Fact(Skip="exception handling")]
        public async Task UnhandledNullReferenceApiException()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled/api/nullreference");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

            var exception = await GetModelAsync<ProblemDetails>(response);

            Assert.Equal(StatusCodes.Status500InternalServerError, exception.Status);
        }

        [Fact(Skip="exception handling")]
        public async Task UnhandledApiExceptionWithContent()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/exceptions/unhandled/content");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

            var exception = await GetModelAsync<ProblemDetails>(response);

            Assert.Equal(StatusCodes.Status500InternalServerError, exception.Status);
        }
    }
}
