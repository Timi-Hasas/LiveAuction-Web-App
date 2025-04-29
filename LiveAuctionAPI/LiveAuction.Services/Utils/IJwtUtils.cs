using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Utils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(AuthUserDTO user);

        public Guid? ValidateJwtToken(string token);
    }
}
