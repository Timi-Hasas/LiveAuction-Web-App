using LiveAuction.Biddings.Models;

namespace LiveAuction.Biddings.Repositories
{
    public interface IBiddingRepository
    {
        Task<Bidding?> GetBiddingAsync(Guid auctionId);

        Task<List<Bidding>?> GetBiddingsAsync();

        Task CreateBiddingAsync(Bidding auction);

        Task UpdateBiddingsAsync(Guid auctionId);
    }
}
