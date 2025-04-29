using LiveAuction.Common.DTO;
using LiveAuction.Gateway.Services.Services.Interfaces;
using LiveAuction.GatewayAPI.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace LiveAuction.GatewayAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsersAsync();

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var result = await _userService.GetUserAsync(userId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UserConfidentialDTO user)
        {
            user.Id = userId;

            await _userService.UpdateUserAsync(user);

            return Accepted();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            await _userService.DeleteUserAsync(userId);

            return Accepted();
        }
    }
}
