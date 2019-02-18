using System.Net.Http;
using System.Net.Http.Headers;

namespace AspNet.WebApi.Server.Tests
{
    public static class HttpClientExtensions
    {
        private const string ApiVersion = "1.0";
        private const string ApiApplicationId = "Unit Tests";

        public static HttpClient SetDefaultHeaders(this HttpClient client, string apiVersion = ApiVersion, string apiApplicationId = ApiApplicationId)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(ApiHeaders.ApiApplicationId, apiApplicationId);
            client.DefaultRequestHeaders.Add(ApiHeaders.ApiVersion, apiVersion);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public static HttpClient ClearAllHeaders(this HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();

            return client;
        }
    }
}