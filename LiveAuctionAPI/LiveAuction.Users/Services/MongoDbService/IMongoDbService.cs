﻿using LiveAuction.Common.DTO;

namespace LiveAuction.Users.Services.MongoDbService
{
    public interface IMongoDbService
    {
        Task<UserConfidentialDTO?> GetUserAsync(Guid userId);

        Task<List<UserConfidentialDTO>?> GetUsersAsync();

        Task CreateUserAsync(UserConfidentialDTO user);

        Task UpdateUserAsync(UserConfidentialDTO user);

        Task DeleteUserAsync(Guid userId);

        Task<UserConfidentialDTO?> GetUserByEmailAsync(string email);
    }
}
