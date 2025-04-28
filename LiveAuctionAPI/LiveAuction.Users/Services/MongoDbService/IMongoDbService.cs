using LiveAuction.Common.DTO;

namespace LiveAuction.Users.Services.MongoDbService
{
    public interface IMongoDbService
    {
        Task<UserDTO?> GetUserAsync(Guid userId);

        Task<List<UserDTO>?> GetUsersAsync();

        Task CreateUserAsync(UserDTO user);

        Task UpdateUserAsync(UserDTO user);

        Task DeleteUserAsync(Guid userId);

        Task<UserDTO?> GetUserByEmailAsync(string email);
    }
}
