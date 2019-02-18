using System;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace AspNet.WebApi.Server.Tests
{
    public abstract class TestsSetup : IClassFixture<TestsFixture>
    {
        internal const string _origin = "https://api.server.test";

        internal HttpClient Client { get; }

        public TestsSetup(TestsFixture fixture)
        {
            Client = fixture.Client;
        }
    }

    public class TestsFixture : IDisposable
    {
        private readonly TestServer _server;

        public TestsFixture()
        {
            var webHostBuilder = new Host().WebHostBuilder<Startup>(Array.Empty<string>());

            _server = new TestServer(webHostBuilder);

            Client = _server.CreateClient();
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);


        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _server.Dispose();
                Client.Dispose();
            }
        }
    }
}
