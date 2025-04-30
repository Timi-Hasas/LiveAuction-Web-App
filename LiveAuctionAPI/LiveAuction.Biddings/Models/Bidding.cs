using LiveAuction.Common.DTO;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LiveAuction.Biddings.Models
{
    public class Bidding
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        [BsonElement("owner")]
        public Owner? Owner { get; set; }

        [BsonElement("auction")]
        public Auction? Auction { get; set; }

        [BsonElement("amount")]
        public decimal Amount { get; set; }

        [BsonElement("timestamp")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Timestamp { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        public BiddingAuctionDTO ToDTO()
        {
            return new BiddingAuctionDTO
            {
                Id = Id,
                Amount = Amount,
                Auction = Auction?.ToDTO(),
                IsActive = IsActive,
                Timestamp = Timestamp,
                Owner = Owner?.ToDTO()
            };
        }
    }

    public static class BiddingDtoMappingExtensions
    {
        public static Bidding? FromDTO(this Bidding currenBidding, BiddingAuctionDTO? bidding)
        {
            currenBidding ??= new Bidding();

            if (bidding == null)
            {
                return null;
            }

            currenBidding.Id = bidding.Id;
            currenBidding.Amount = bidding.Amount;
            currenBidding.Auction = new Auction().FromDTO(bidding.Auction);
            currenBidding.IsActive = bidding.IsActive;
            currenBidding.Timestamp = bidding.Timestamp;
            currenBidding.Owner = new Owner().FromDTO(bidding.Owner);

            return currenBidding;
        }
    }
}
