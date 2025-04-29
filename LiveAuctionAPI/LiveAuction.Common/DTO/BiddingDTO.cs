namespace LiveAuction.Common.DTO
{
    public class BiddingDTO
    {
        public Guid Id { get; set; }

        public UserDTO? Owner { get; set; }

        public Guid AuctionId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsActive { get; set; }

        public bool IsCurrentHighestBid { get; set; }
    }
}
