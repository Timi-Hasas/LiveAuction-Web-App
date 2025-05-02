using LiveAuction.Common.DTO;

namespace LiveAuction.Biddings.Services.MongoDbService
{
    public interface IMongoDbService
    {
        Task<BiddingAuctionDTO?> GetBiddingAsync(Guid biddingId);

        Task<List<BiddingAuctionDTO>?> GetBiddingsAsync(Guid? ownerId, int? skip = 0, int? take = 10);

        Task CreateBiddingAsync(BiddingAuctionDTO bidding);

        Task UpdateBiddingsAsync(Guid auctionId);
    }
}
