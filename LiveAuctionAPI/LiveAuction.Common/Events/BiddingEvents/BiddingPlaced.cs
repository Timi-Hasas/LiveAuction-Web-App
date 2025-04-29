using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.BidEvents
{
    public class BiddingPlaced
    {
        public BiddingDTO Bidding { get; set; }
    }
}
