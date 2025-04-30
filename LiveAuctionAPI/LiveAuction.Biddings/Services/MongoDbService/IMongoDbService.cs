using LiveAuction.Common.DTO;

namespace LiveAuction.Biddings.Services.MongoDbService
{
    public interface IMongoDbService
    {
        Task<BiddingAuctionDTO?> GetBiddingAsync(Guid biddingId);

        Task<List<BiddingAuctionDTO>?> GetBiddingsAsync();

        Task CreateBiddingAsync(BiddingAuctionDTO bidding);

        Task UpdateBiddingsAsync(Guid auctionId);
    }
}
