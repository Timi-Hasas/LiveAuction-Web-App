using LiveAuction.Common.DTO;

namespace LiveAuction.Users.Services.DataWriteServices
{
    public interface IUserDataWriteService
    {
        Task CreateUserAsync(AuthUserDTO user);

        Task UpdateUserAsync(AuthUserDTO user);

        Task DeleteUserAsync(Guid userId);
    }
}
