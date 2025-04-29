using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Clients.UserClient
{
    public interface IUserClient
    {
        Task<UserConfidentialDTO?> GetUserAsync(Guid userId);

        Task<IEnumerable<UserConfidentialDTO>?> GetUsersAsync();

        Task<UserConfidentialDTO?> GetUserByEmailAsync(string email);
    }
}
