using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.UserEvents
{
    public class UserUpdated
    {
        public AuthUserDTO User { get; set; }
    }
}
