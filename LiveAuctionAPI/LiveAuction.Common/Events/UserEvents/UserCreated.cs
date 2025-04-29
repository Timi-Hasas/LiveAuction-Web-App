using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.UserEvents
{
    public class UserCreated
    {
        public UserConfidentialDTO User { get; set; }
    }
}
