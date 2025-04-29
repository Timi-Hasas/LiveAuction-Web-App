using LiveAuction.Common.DTO;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveAuction.Auctions.Models
{
    public class Auction
    {
        [BsonElement("id")]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("auctionedItemName")]
        public string AuctionedItemName { get; set; }

        [BsonElement("startingPrice")]
        public decimal StartingPrice { get; set; }

        [BsonElement("minimumBid")]
        public decimal MinimumBid { get; set; }

        [BsonElement("auctionTimeInMinutes")]
        public int AuctionTimeInMinutes { get; set; }

        [BsonElement("owner")]
        public Owner? Owner { get; set; }

        [BsonElement("biddings")]
        public List<Bidding>? Biddings { get; set; }

        [BsonElement("currentHighestBidding")]
        public Bidding? CurrentHighestBidding { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        public AuctionDTO ToDTO()
        {
            return new AuctionDTO
            {
                Id = Id,
                AuctionedItemName = AuctionedItemName,
                AuctionTimeInMinutes = AuctionTimeInMinutes,
                Description = Description,
                MinimumBid = MinimumBid,
                Name = Name,
                StartingPrice = StartingPrice,
                Timestamp = Timestamp,
                CurrentHighestBidding = CurrentHighestBidding?.ToDTO(),
                Owner = Owner?.ToDTO(),
                Biddings = Biddings?.Select(b => b.ToDTO()).ToList()
            };
        }
    }

    public static class AuctionDtoMappingExtensions
    {
        public static Auction? FromDTO(this Auction currentAuction, AuctionDTO auction)
        {
            currentAuction ??= new Auction();

            if (auction == null)
            {
                return null;
            }

            currentAuction.Id = auction.Id;
            currentAuction.AuctionedItemName = auction.AuctionedItemName;
            currentAuction.AuctionTimeInMinutes = auction.AuctionTimeInMinutes;
            currentAuction.Description = auction.Description;
            currentAuction.MinimumBid = auction.MinimumBid;
            currentAuction.Name = auction.Name;
            currentAuction.StartingPrice = auction.StartingPrice;
            currentAuction.Timestamp = auction.Timestamp;
            currentAuction.CurrentHighestBidding = (new Bidding())?.FromDTO(auction.CurrentHighestBidding);
            currentAuction.Owner = (new Owner()).FromDTO(auction.Owner);
            currentAuction.Biddings = auction.Biddings?.Select(b => new Bidding().FromDTO(auction.CurrentHighestBidding)).ToList();

            return currentAuction;
        }
    }
}
