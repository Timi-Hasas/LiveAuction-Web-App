using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.MongoDbService
{
    public interface IMongoDbService
    {
        Task<AuctionBiddingDTO?> GetAuctionAsync(Guid auctionId);

        Task<List<AuctionBiddingDTO>?> GetAuctionsAsync();

        Task CreateAuctionAsync(AuctionBiddingDTO auction);

        Task UpdateAuctionAsync(AuctionBiddingDTO auction);

        Task DeleteAuctionAsync(Guid auctionId);
    }
}
