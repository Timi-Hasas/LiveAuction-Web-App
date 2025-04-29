using LiveAuction.Common.DTO;

namespace LiveAuction.Users.Services.MongoDbService
{
    public interface IMongoDbService
    {
        Task<AuthUserDTO?> GetUserAsync(Guid userId);

        Task<List<AuthUserDTO>?> GetUsersAsync();

        Task CreateUserAsync(AuthUserDTO user);

        Task UpdateUserAsync(AuthUserDTO user);

        Task DeleteUserAsync(Guid userId);

        Task<AuthUserDTO?> GetUserByEmailAsync(string email);
    }
}
