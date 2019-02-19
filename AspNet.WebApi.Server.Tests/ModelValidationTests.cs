using AspNet.WebApi.Server.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public partial class ServerTests
    {
        [Fact]
        public async Task ValidModel()
        {
            var response = await Client.SetDefaultHeaders().GetAsync("/model?param1=0&param2=False");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var expected = SuccessModel.Default;
            var actual = await GetModelAsync<SuccessModel>(response);

            //DeepAssert.Equal(expected, actual);
            Assert.Equal(expected.Success, actual.Success);
        }

        [Fact]
        public async Task NullModel()
        {
            var data = new StringContent(string.Empty, Encoding.Default, "application/json");
            var response = await Client.SetDefaultHeaders().PostAsync("/model", data);

            Assert.NotEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task InvalidModel()
        {
            var expected = "{\"param1\":[\"The value \\u0027abc\\u0027 is not valid.\"],\"param2\":[\"The value \\u0027def\\u0027 is not valid.\"]}";
            var response = await Client.SetDefaultHeaders().GetAsync("/model?param1=abc&param2=def");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();

            Assert.Equal(expected, body);
        }

        [Fact]
        public async Task IgnoreAttributeModel()
        {
            var expected = "{\"param\":[\"The value \\u0027abc\\u0027 is not valid.\"]}";
            var response = await Client.SetDefaultHeaders().GetAsync("/model/ignore/validation?param=abc");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();

            Assert.Equal(expected, body);
        }
    }
}
