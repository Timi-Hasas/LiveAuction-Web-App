using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Clients.AuctionClient
{
    public interface IAuctionClient
    {
        Task<AuctionBiddingDTO?> GetAuctionAsync(Guid auctionId);

        Task<IEnumerable<AuctionBiddingDTO>?> GetAuctionsAsync(Guid? ownerId, int? skip = 0, int? take = 10);
    }
}
