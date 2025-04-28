using LiveAuction.Common.DTO;

namespace LiveAuction.Users.Services.DataWriteServices
{
    public interface IUserDataWriteService
    {
        Task CreateUserAsync(UserDTO user);

        Task UpdateUserAsync(UserDTO user);

        Task DeleteUserAsync(Guid userId);
    }
}
