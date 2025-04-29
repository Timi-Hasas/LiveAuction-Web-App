using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.UserEvents
{
    public class UserCreated
    {
        public AuthUserDTO User { get; set; }
    }
}
