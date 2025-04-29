using LiveAuction.Common.DTO;
using LiveAuction.Gateway.Services.Clients;

namespace LiveAuction.Gateway.Services.Clients.UserClient
{
    public class UserClient : BaseClient, IUserClient
    {
        public UserClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<AuthUserDTO?> GetUserAsync(Guid userId)
            => await GetAsync<AuthUserDTO>(UserEndpoints.GetUserEndpoint(userId));

        public async Task<AuthUserDTO?> GetUserByEmailAsync(string email)
            => await GetAsync<AuthUserDTO>(UserEndpoints.GetUserByEmailEndpoint(email));

        public async Task<IEnumerable<AuthUserDTO>?> GetUsersAsync()
            => await GetAsync<IEnumerable<AuthUserDTO>>(UserEndpoints.GetUsersEndpoint());
    }
}
