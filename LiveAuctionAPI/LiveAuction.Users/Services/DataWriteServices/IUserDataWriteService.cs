using LiveAuction.Common.DTO;

namespace LiveAuction.Users.Services.DataWriteServices
{
    public interface IUserDataWriteService
    {
        Task CreateUserAsync(UserConfidentialDTO user);

        Task UpdateUserAsync(UserConfidentialDTO user);

        Task DeleteUserAsync(Guid userId);
    }
}
