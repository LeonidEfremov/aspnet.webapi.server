using Microsoft.Extensions.Configuration;

namespace AspNet.WebApi.Server.Example
{
    /// <inheritdoc cref="Server.Startup"/> />
    public class Startup : Server.Startup
    {
        /// <inheritdoc />
        public Startup(IConfiguration configuration) : base(configuration) { }
    }
}
