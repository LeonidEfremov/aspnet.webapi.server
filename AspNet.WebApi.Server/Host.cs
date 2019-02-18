using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AspNet.WebApi.Server
{
    /// <summary>Host for Service.</summary>
    public abstract class Host
    {
        /// <summary>Create new WebHost.</summary>
        /// <param name="args">Args.</param>
        /// <typeparam name="T"><see cref="Startup"/> instance.</typeparam>
        /// <returns><see cref="IWebHostBuilder"/>.</returns>
        public virtual IWebHostBuilder WebHostBuilder<T>(string[] args)
            where T : class
        {
            var pathToContentRoot = System.IO.Path.GetDirectoryName(GetType().Assembly.Location);

            return WebHost.CreateDefaultBuilder<T>(args)
                .UseContentRoot(pathToContentRoot);
        }
    }
}