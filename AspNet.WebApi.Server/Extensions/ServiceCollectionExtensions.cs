using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNet.WebApi.Server.Extensions
{
    /// <summary><see cref="IServiceCollection"/> extensions.</summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>Add DbContext.</summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="action">Action.</param>
        public static IServiceCollection AddDbContext(this IServiceCollection services, Action<IServiceCollection> action)
        {
            action(services);

            return services;
        }
    }
}
