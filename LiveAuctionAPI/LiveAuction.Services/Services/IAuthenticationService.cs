using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Services
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(LoginDTO login);

        Task RegisterAsync(UserDTO user);
    }
}
