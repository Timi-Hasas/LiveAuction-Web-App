using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.UserEvents
{
    public class UserUpdated
    {
        public UserConfidentialDTO User { get; set; }
    }
}
