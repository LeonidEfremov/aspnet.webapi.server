using Microsoft.AspNetCore.Hosting;
using NLog.Web;

namespace AspNet.WebApi.Server.Example
{
    /// <inheritdoc />
    public class Host : Server.Host
    {
        /// <inheritdoc />
        public override IWebHostBuilder WebHostBuilder<T>(string[] args) => base.WebHostBuilder<T>(args).UseNLog();
    }
}