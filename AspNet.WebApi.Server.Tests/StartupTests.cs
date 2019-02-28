using Xunit;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public partial class ServerTests
    {
        [Fact]
        public void ApiInfo()
        {
            var apiInfo = new Startup(null).ApiInfo;

            Assert.Equal("AspNet.WebApi.Server.Tests", apiInfo.AssemblyName);
            Assert.Equal("API Service base library for API Services.", apiInfo.Description);
            Assert.Equal("1.0.7.0", apiInfo.Version.ToString());
            Assert.Equal("AspNet.WebApi.Server.Tests.v1", apiInfo.ServiceName);
            Assert.Equal("1.0", apiInfo.ApiVersion);
            Assert.Equal("AspNet.WebApi.Server.Tests", apiInfo.DisplayName);
        }
    }
}
