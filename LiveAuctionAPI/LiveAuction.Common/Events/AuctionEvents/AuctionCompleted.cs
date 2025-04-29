using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.AuctionEvents
{
    public class AuctionCompleted
    {
        public Guid AuctionId { get; set; }
    }
}
