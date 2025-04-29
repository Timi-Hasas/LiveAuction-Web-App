using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Clients.UserClient
{
    public interface IUserClient
    {
        Task<AuthUserDTO?> GetUserAsync(Guid userId);

        Task<IEnumerable<AuthUserDTO>?> GetUsersAsync();

        Task<AuthUserDTO?> GetUserByEmailAsync(string email);
    }
}
