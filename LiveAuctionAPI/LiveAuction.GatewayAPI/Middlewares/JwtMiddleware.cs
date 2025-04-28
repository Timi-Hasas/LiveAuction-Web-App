using LiveAuction.Gateway.Services.Services;
using LiveAuction.Gateway.Services.Utils;

namespace LiveAuction.GatewayAPI.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
            var userId = jwtUtils.ValidateJwtToken(token ?? string.Empty);
            if (userId != null && userId.HasValue)
            {
                context.Items["User"] = await userService.GetUserAsync(userId.Value);
            }

            await _next(context);
        }
    }
}
