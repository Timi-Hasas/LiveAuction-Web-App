using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Services.Interfaces
{
    public interface IAuctionService
    {
        Task<AuctionBiddingDTO?> GetAuctionAsync(Guid auctionId);

        Task<IEnumerable<AuctionBiddingDTO>?> GetAuctionsAsync(Guid? ownerId, int? skip = 0, int? take = 10);

        Task CreateAuctionAsync(AuctionDTO auction);

        Task UpdateAuctionAsync(AuctionDTO auction);

        Task DeleteAuctionAsync(Guid auctionId);

        Task CompleteAuctionAsync(Guid auctionId);
    }
}
