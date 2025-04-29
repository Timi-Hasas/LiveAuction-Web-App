using LiveAuction.Auctions.Models;

namespace LiveAuction.Auctions.Repositories
{
    public interface IAuctionRepository
    {
        Task<Auction?> GetAuctionAsync(Guid auctionId);

        Task<List<Auction>?> GetAuctionsAsync();

        Task CreateAuctionAsync(Auction auction);

        Task UpdateAuctionAsync(Auction auction);

        Task DeleteAuctionAsync(Guid auctionId);
    }
}
