using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.MongoDbService
{
    public interface IMongoDbService
    {
        Task<AuctionDTO?> GetAuctionAsync(Guid auctionId);

        Task<List<AuctionDTO>?> GetAuctionsAsync();

        Task CreateAuctionAsync(AuctionDTO auction);

        Task UpdateAuctionAsync(AuctionDTO auction);

        Task DeleteAuctionAsync(Guid auctionId);
    }
}
