using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserConfidentialDTO?> GetUserAsync(Guid userId);

        Task<IEnumerable<UserConfidentialDTO>?> GetUsersAsync();

        Task CreateUserAsync(UserConfidentialDTO user);

        Task UpdateUserAsync(UserConfidentialDTO user);

        Task DeleteUserAsync(Guid userId);

        Task<UserConfidentialDTO?> GetUserByEmailAsync(string email);
    }
}
