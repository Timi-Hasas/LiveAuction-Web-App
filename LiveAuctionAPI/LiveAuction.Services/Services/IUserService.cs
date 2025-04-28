using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Services
{
    public interface IUserService
    {
        Task<UserDTO?> GetUserAsync(Guid userId);

        Task<IEnumerable<UserDTO>?> GetUsersAsync();

        Task CreateUserAsync(UserDTO user);

        Task UpdateUserAsync(UserDTO user);

        Task DeleteUserAsync(Guid userId);

        Task<UserDTO?> GetUserByEmailAsync(string email);
    }
}
