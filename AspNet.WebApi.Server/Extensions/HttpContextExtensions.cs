using Microsoft.AspNetCore.Http;

namespace AspNet.WebApi.Server.Extensions
{
    /// <summary>Extensions for <see cref="HttpContext"/>.</summary>
    public static class HttpContextExtensions
    {
        /// <summary>Set context item with corresponded Request header.</summary>
        /// <param name="context"><see cref="HttpContext"/>.</param>
        /// <param name="key">Header name.</param>
        /// <returns>Return <see cref="HttpContext"/>.</returns>
        public static HttpContext SetContextItemByHeader(this HttpContext context, string key)
        {
            context.Items[key] = context.Request.Headers[key];

            return context;
        }
    }
}