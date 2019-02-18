using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace AspNet.WebApi.Server.Example
{
    /// <summary>Server.Example program.</summary>
    public static class Program
    {
        /// <summary>Entry point.</summary>
        /// <param name="args">Arguments.</param>
        /// <returns>Void.</returns>
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            await host.RunAsync();
        }

        /// <summary>Create WebHost Builder.</summary>
        /// <param name="args">Arguments.</param>
        /// <returns>Instance <see cref="IWebHostBuilder"/>.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => new Host().WebHostBuilder<Startup>(args);
    }
}