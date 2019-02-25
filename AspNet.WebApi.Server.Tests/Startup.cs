using AspNet.WebApi.Server.Tests.Providers;
using AspNet.WebApi.Server.Tests.Providers.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNet.WebApi.Server.Tests
{
    /// <inheritdoc />
    public class Startup : Server.Startup
    {
        /// <inheritdoc />
        public Startup(IConfiguration configuration) : base(configuration) { }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDataProvider>(_ => new DataProvider("connectionString"));

            base.ConfigureServices(services);
        }

        protected override void ConfigureCorsPolicy(CorsPolicyBuilder builder) =>
            builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .WithOrigins(TestsSetup.Origin)
                .Build();
    }
}