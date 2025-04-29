using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.AuctionEvents
{
    public class AuctionUpdated
    {
        public AuctionBiddingDTO Auction { get; set; }
    }
}
