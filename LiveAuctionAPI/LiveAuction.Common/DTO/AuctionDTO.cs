namespace LiveAuction.Common.DTO
{
    public class AuctionDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AuctionedItemName { get; set; }

        public decimal StartingPrice { get; set; }

        public decimal MinimumBid { get; set; }

        public int AuctionTimeInMinutes { get; set; }

        public UserDTO? Owner { get; set; }

        public IEnumerable<BiddingDTO>? Biddings { get; set; }

        public BiddingDTO? CurrentHighestBidding { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
