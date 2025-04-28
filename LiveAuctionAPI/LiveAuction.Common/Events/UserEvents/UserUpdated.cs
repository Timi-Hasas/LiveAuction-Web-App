using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.UserEvents
{
    public class UserUpdated
    {
        public UserDTO User { get; set; }
    }
}
