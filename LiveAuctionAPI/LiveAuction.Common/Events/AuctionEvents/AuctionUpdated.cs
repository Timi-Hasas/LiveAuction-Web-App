using LiveAuction.Common.DTO;

namespace LiveAuction.Common.Events.AuctionEvents
{
    public class AuctionUpdated
    {
        public AuctionDTO Auction { get; set; }
    }
}
