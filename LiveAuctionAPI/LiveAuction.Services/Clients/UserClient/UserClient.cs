using LiveAuction.Common.DTO;
using LiveAuction.Gateway.Services.Clients;

namespace LiveAuction.Gateway.Services.Clients.UserClient
{
    public class UserClient : BaseClient, IUserClient
    {
        public UserClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<UserDTO?> GetUserAsync(Guid userId)
            => await GetAsync<UserDTO>(UserEndpoints.GetUserEndpoint(userId));

        public async Task<UserDTO?> GetUserByEmailAsync(string email)
            => await GetAsync<UserDTO>(UserEndpoints.GetUserByEmailEndpoint(email));

        public async Task<IEnumerable<UserDTO>?> GetUsersAsync()
            => await GetAsync<IEnumerable<UserDTO>>(UserEndpoints.GetUsersEndpoint());
    }
}
