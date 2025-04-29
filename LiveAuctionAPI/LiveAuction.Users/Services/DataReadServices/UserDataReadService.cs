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

        public async Task<UserConfidentialDTO?> GetUserAsync(Guid userId)
        {
            return await _mongoDbService.GetUserAsync(userId);
        }

        public async Task<UserConfidentialDTO?> GetUserByEmailAsync(string email)
        {
            return await _mongoDbService.GetUserByEmailAsync(email);
        }

        public async Task<List<UserConfidentialDTO>?> GetUsersAsync()
        {
            return await _mongoDbService.GetUsersAsync();
        }
    }
}
