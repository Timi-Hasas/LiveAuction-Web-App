using LiveAuction.Common.DTO;
using LiveAuction.Users.Services.MongoDbService;

namespace LiveAuction.Users.Services.DataWriteServices
{
    public class UserDataWriteService : IUserDataWriteService
    {
        private readonly IMongoDbService _mongoDbService;

        public UserDataWriteService(IMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task CreateUserAsync(UserConfidentialDTO user)
        {
            await _mongoDbService.CreateUserAsync(user);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            await _mongoDbService.DeleteUserAsync(userId);
        }

        public async Task UpdateUserAsync(UserConfidentialDTO user)
        {
            await _mongoDbService.UpdateUserAsync(user);
        }
    }
}
