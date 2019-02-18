using AspNet.WebApi.Server.Tests.Providers.Interfaces;

namespace AspNet.WebApi.Server.Tests.Providers
{
    public class DataProvider : IDataProvider
    {
        private readonly string _connectionString;

        public DataProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetSomeData(string param) => $"{_connectionString}: {param}";
    }
}
