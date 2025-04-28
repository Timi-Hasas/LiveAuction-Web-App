using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.UserEvents
{
    public class UserCreated
    {
        public UserDTO User { get; set; }
    }
}
