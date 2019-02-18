using System.Threading;
using System.Threading.Tasks;
using App.Metrics.Health;

namespace AspNet.WebApi.Server.Example.Health
{
    /// <inheritdoc />
    public class CustomHealthCheck : HealthCheck
    {
        /// <inheritdoc />
        public CustomHealthCheck() : base("Custom Health Check") { }

        /// <inheritdoc />
        protected override ValueTask<HealthCheckResult> CheckAsync(
            CancellationToken cancellationToken = default) =>
            new ValueTask<HealthCheckResult>(HealthCheckResult.Unhealthy("fff"));
    }
}