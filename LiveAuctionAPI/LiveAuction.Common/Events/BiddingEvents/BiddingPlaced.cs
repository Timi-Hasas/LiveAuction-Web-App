using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.BiddingEvents
{
    public class BiddingPlaced
    {
        public BiddingAuctionDTO Bidding { get; set; }
    }
}
