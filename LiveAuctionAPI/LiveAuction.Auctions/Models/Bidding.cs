﻿using LiveAuction.Common.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveAuction.Auctions.Models
{
    public class Bidding
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        [BsonElement("owner")]
        public Owner? Owner { get; set; }

        [BsonElement("auctionId")]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid AuctionId { get; set; }

        [BsonElement("amount")]
        public decimal Amount { get; set; }

        [BsonElement("timestamp")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Timestamp { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        public BiddingDTO ToDTO()
        {
            return new BiddingDTO
            {
                Id = Id,
                Amount = Amount,
                AuctionId = AuctionId,
                IsActive = IsActive,
                Timestamp = Timestamp,
                Owner = Owner?.ToDTO()
            };
        }
    }

    public static class BiddingDtoMappingExtensions
    {
        public static Bidding? FromDTO(this Bidding currenBidding, BiddingDTO? bidding)
        {
            currenBidding ??= new Bidding();

            if (bidding == null)
            {
                return null;
            }

            currenBidding.Id = bidding.Id;
            currenBidding.Amount = bidding.Amount;
            currenBidding.AuctionId = bidding.AuctionId;
            currenBidding.IsActive = bidding.IsActive;
            currenBidding.Timestamp = bidding.Timestamp;
            currenBidding.Owner = new Owner().FromDTO(bidding.Owner);

            return currenBidding;
        }
    }
}
