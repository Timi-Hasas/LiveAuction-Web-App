namespace LiveAuction.Common.DTO
{
    public class BiddingAuctionDTO
    {
        public Guid Id { get; set; }

        public UserInfoDTO? Owner { get; set; }

        public AuctionBiddingDTO? Auction { get; set; }

        public decimal Amount { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsActive { get; set; }
    }
}
