using LiveAuction.Users.Models;

namespace LiveAuction.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(Guid userId);

        Task<List<User>?> GetUsersAsync();

        Task CreateUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(Guid userId);

        Task<User?> GetUserByEmailAsync(string email);
    }
}
