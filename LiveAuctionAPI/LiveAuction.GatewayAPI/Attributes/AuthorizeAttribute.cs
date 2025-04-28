using LiveAuction.Common.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LiveAuction.GatewayAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var unauthorizedResult = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };

            if (!context.HttpContext.Items.TryGetValue("User", out var user) && user == null)
            {
                context.Result = unauthorizedResult;
            }

            var userDto = user as UserDTO;
            if (userDto == null)
            {
                context.Result = unauthorizedResult;
            }
        }
    }
}
