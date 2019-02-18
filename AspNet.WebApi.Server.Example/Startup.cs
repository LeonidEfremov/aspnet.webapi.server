using App.Metrics.Health;
using AspNet.WebApi.Server.Example.Health;
using Microsoft.Extensions.Configuration;

namespace AspNet.WebApi.Server.Example
{
    /// <inheritdoc cref="Server.Startup"/> />
    public class Startup : Server.Startup
    {
        /// <inheritdoc />
        public Startup(IConfiguration configuration) : base(configuration) { }

        /// <inheritdoc />
        protected override void ConfigureHealth(IHealthBuilder builder)
        {
            builder.HealthChecks.AddCheck<CustomHealthCheck>();

            base.ConfigureHealth(builder);
        }
    }
}
