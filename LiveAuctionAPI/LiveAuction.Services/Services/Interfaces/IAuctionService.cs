using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Services.Interfaces
{
    public interface IAuctionService
    {
        Task<AuctionDTO?> GetAuctionAsync(Guid auctionId);

        Task<IEnumerable<AuctionDTO>?> GetAuctionsAsync();

        Task CreateAuctionAsync(AuctionDTO auction);

        Task UpdateAuctionAsync(AuctionDTO auction);

        Task DeleteAuctionAsync(Guid auctionId);
    }
}
