using Newtonsoft.Json;

namespace LiveAuction.Gateway.Services.Clients
{
    public abstract class BaseClient : IBaseClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T?> GetAsync<T>(string route)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(route);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T?>(responseJson);

            return result;
        }
    }
}
