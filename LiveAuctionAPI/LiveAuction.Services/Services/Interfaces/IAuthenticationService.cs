using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(LoginDTO login);

        Task RegisterAsync(UserConfidentialDTO user);
    }
}
