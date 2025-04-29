namespace LiveAuction.Common.DTO
{
    public class PlaceBiddingDTO
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }

        public Guid AuctionId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
