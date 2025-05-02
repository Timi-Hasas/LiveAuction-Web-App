using LiveAuction.Biddings.Models;

namespace LiveAuction.Biddings.Repositories
{
    public interface IBiddingRepository
    {
        Task<Bidding?> GetBiddingAsync(Guid auctionId);

        Task<List<Bidding>?> GetBiddingsAsync(Guid? ownerId, int? skip = 0, int? take = 10);

        Task CreateBiddingAsync(Bidding auction);

        Task UpdateBiddingsAsync(Guid auctionId);
    }
}
