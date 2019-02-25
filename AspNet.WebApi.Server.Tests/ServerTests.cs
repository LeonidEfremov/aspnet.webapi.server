using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public partial class ServerTests : TestsSetup
    {
        public ServerTests(TestsFixture fixture) : base(fixture) { }

        public async Task<T> GetModelAsync<T>(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(body, JsonSerializerSettings);

            return await Task.FromResult(result);
        }
    }
}