using LiveAuction.Common.DTO;
using LiveAuction.Gateway.Services.Clients;

namespace LiveAuction.Gateway.Services.Clients.UserClient
{
    public class UserClient : BaseClient, IUserClient
    {
        public UserClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<UserConfidentialDTO?> GetUserAsync(Guid userId)
            => await GetAsync<UserConfidentialDTO>(UserEndpoints.GetUserEndpoint(userId));

        public async Task<UserConfidentialDTO?> GetUserByEmailAsync(string email)
            => await GetAsync<UserConfidentialDTO>(UserEndpoints.GetUserByEmailEndpoint(email));

        public async Task<IEnumerable<UserConfidentialDTO>?> GetUsersAsync()
            => await GetAsync<IEnumerable<UserConfidentialDTO>>(UserEndpoints.GetUsersEndpoint());
    }
}
