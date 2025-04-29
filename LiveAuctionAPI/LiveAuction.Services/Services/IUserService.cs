using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Services
{
    public interface IUserService
    {
        Task<AuthUserDTO?> GetUserAsync(Guid userId);

        Task<IEnumerable<AuthUserDTO>?> GetUsersAsync();

        Task CreateUserAsync(AuthUserDTO user);

        Task UpdateUserAsync(AuthUserDTO user);

        Task DeleteUserAsync(Guid userId);

        Task<AuthUserDTO?> GetUserByEmailAsync(string email);
    }
}
