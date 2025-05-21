using LiveAuction.Users.Models;
using LiveAuction.Users.Services.DataReadServices;
using Microsoft.AspNetCore.Mvc;

namespace LiveAuction.Users.Endpoints
{
    public static class UserEndpoints
    {
        public static void RegisterUserEndpoints(this WebApplication app)
        {
            var userEndpoints = app.MapGroup("/api/v1/users");

            userEndpoints.MapGet("", async (IUserDataReadService userService)
                => Results.Ok(await userService.GetUsersAsync()));

            userEndpoints.MapGet("/{userId}",
                async (Guid userId, IUserDataReadService userService) =>
            {
                var result = await userService.GetUserAsync(userId);

                return result == null
                    ? Results.NotFound()
                    : Results.Ok(result);
            });

            userEndpoints.MapGet("/filter",
                async ([FromQuery(Name = "email")] string email, IUserDataReadService userService) => 
            {
                var result = await userService.GetUserByEmailAsync(email);

                return Results.Ok(result);
            });
        }
    }
}
