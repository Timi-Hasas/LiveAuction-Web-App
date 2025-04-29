using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Clients.AuctionClient
{
    public interface IAuctionClient
    {
        Task<AuctionDTO?> GetAuctionAsync(Guid auctionId);

        Task<IEnumerable<AuctionDTO>?> GetAuctionsAsync();
    }
}
