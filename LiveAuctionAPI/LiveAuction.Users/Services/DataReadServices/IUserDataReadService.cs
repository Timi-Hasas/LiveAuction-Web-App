using LiveAuction.Common.DTO;

namespace LiveAuction.Users.Services.DataReadServices
{
    public interface IUserDataReadService
    {
        Task<UserConfidentialDTO?> GetUserAsync(Guid userId);

        Task<UserConfidentialDTO?> GetUserByEmailAsync(string email);

        Task<List<UserConfidentialDTO>?> GetUsersAsync();
    }
}
