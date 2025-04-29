using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.AuctionEvents
{
    public class AuctionCreated
    {
        public AuctionBiddingDTO Auction { get; set; }
    }
}
