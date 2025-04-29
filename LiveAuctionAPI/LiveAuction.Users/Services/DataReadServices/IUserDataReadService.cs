using LiveAuction.Common.DTO;

namespace LiveAuction.Users.Services.DataReadServices
{
    public interface IUserDataReadService
    {
        Task<AuthUserDTO?> GetUserAsync(Guid userId);

        Task<AuthUserDTO?> GetUserByEmailAsync(string email);

        Task<List<AuthUserDTO>?> GetUsersAsync();
    }
}
