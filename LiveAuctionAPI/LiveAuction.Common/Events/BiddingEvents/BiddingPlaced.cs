using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.BiddingEvents
{
    public class BiddingPlaced
    {
        public BiddingDTO Bidding { get; set; }
    }
}
