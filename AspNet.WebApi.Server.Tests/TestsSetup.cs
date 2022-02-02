using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using Xunit;

namespace AspNet.WebApi.Server.Tests
{
    public abstract class TestsSetup : IClassFixture<TestsFixture>
    {
        internal const string Origin = "https://api.server.test";
        
        internal HttpClient Client { get; }
        internal JsonSerializerSettings JsonSerializerSettings { get; }

        public TestsSetup(TestsFixture fixture)
        {
            Client = fixture.Client;
            JsonSerializerSettings = fixture.JsonSerializerSettings;
        }
    }

    public class TestsFixture : IDisposable
    {
        private readonly TestServer _server;

        public HttpClient Client { get; }
        public JsonSerializerSettings JsonSerializerSettings { get; }

        public TestsFixture()
        {
            var webHostBuilder = new Host().WebHostBuilder<Startup>(Array.Empty<string>());

            _server = new TestServer(webHostBuilder);
            Client = _server.CreateClient();

            //var mvcJsonOptions = (IOptions<MvcJsonOptions>)_server.Host.Services.GetService(typeof(IOptions<MvcJsonOptions>));
            //JsonSerializerSettings = mvcJsonOptions.Value.SerializerSettings;
        }

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
