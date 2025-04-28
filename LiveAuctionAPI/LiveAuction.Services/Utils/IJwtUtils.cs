using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Utils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(UserDTO user);

        public Guid? ValidateJwtToken(string token);
    }
}
