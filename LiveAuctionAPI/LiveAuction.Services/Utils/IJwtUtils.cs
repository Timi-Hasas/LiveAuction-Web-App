using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Utils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(UserConfidentialDTO user);

        public Guid? ValidateJwtToken(string token);
    }
}
