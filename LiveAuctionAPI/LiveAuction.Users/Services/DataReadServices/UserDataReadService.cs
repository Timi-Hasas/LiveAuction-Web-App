using LiveAuction.Common.DTO;
using LiveAuction.Users.Services.MongoDbService;

namespace LiveAuction.Users.Services.DataReadServices
{
    public class UserDataReadService : IUserDataReadService
    {
        private readonly IMongoDbService _mongoDbService;

        public UserDataReadService(IMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task<UserDTO?> GetUserAsync(Guid userId)
        {
            return await _mongoDbService.GetUserAsync(userId);
        }

        public async Task<UserDTO?> GetUserByEmailAsync(string email)
        {
            return await _mongoDbService.GetUserByEmailAsync(email);
        }

        public async Task<List<UserDTO>?> GetUsersAsync()
        {
            return await _mongoDbService.GetUsersAsync();
        }
    }
}
