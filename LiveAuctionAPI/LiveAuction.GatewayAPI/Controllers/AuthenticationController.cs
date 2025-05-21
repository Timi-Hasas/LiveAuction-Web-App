using LiveAuction.Common.DTO;
using LiveAuction.Gateway.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LiveAuction.GatewayAPI.Controllers
{
    [ApiController]
    [Route("api/v1/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var result = await _authenticationService.LoginAsync(login);

            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserConfidentialDTO user)
        {
            await _authenticationService.RegisterAsync(user);

            return Accepted();
        }
    }
}

