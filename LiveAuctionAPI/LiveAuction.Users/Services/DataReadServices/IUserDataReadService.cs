using LiveAuction.Common.DTO;

namespace LiveAuction.Users.Services.DataReadServices
{
    public interface IUserDataReadService
    {
        Task<UserDTO?> GetUserAsync(Guid userId);

        Task<UserDTO?> GetUserByEmailAsync(string email);

        Task<List<UserDTO>?> GetUsersAsync();
    }
}
