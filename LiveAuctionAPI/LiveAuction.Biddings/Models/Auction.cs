using LiveAuction.Common.DTO;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LiveAuction.Biddings.Models
{
    public class Auction
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
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

        [BsonElement("timestamp")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Timestamp { get; set; }

        [BsonElement("isCompleted")]
        public bool IsCompleted { get; set; }

        public AuctionBiddingDTO ToDTO()
        {
            return new AuctionBiddingDTO
            {
                Id = Id,
                AuctionedItemName = AuctionedItemName,
                AuctionTimeInMinutes = AuctionTimeInMinutes,
                Description = Description,
                MinimumBid = MinimumBid,
                Name = Name,
                StartingPrice = StartingPrice,
                Timestamp = Timestamp,
                IsCompleted = IsCompleted,
                Owner = Owner?.ToDTO(),
            };
        }
    }

    public static class AuctionDtoMappingExtensions
    {
        public static Auction? FromDTO(this Auction currentAuction, AuctionBiddingDTO? auction)
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
            currentAuction.IsCompleted = auction.IsCompleted;
            currentAuction.Owner = (new Owner()).FromDTO(auction.Owner);

            return currentAuction;
        }
    }
}
