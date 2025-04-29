using LiveAuction.Common.DTO;
using LiveAuction.Gateway.Services.Utils;
using BCryptNet = BCrypt.Net.BCrypt;

namespace LiveAuction.Gateway.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IJwtUtils _jwtUtils;

        public AuthenticationService(IUserService userService, IJwtUtils jwtUtils)
        {
            _userService = userService;
            _jwtUtils = jwtUtils;
        }

        public async Task<string> LoginAsync(LoginDTO login)
        {
            var user = await _userService.GetUserByEmailAsync(login.Email);

            if (user == null || !BCryptNet.Verify(login.Password, user.Password))
            {
                throw new Exception("Username or password is incorrect");
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return jwtToken;
        }

        public async Task RegisterAsync(AuthUserDTO user)
        {
            await _userService.CreateUserAsync(user);
        }
    }
}
