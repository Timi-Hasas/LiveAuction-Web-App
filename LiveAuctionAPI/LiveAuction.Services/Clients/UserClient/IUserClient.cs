using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Clients.UserClient
{
    public interface IUserClient
    {
        Task<UserDTO?> GetUserAsync(Guid userId);

        Task<IEnumerable<UserDTO>?> GetUsersAsync();

        Task<UserDTO?> GetUserByEmailAsync(string email);
    }
}
