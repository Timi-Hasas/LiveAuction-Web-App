using LiveAuction.Common.DTO;

namespace LiveAuction.Gateway.Services.Services.Interfaces
{
    public interface IBiddingService
    {
        Task PlaceBiddingAsync(PlaceBiddingDTO bidding);

        Task<BiddingAuctionDTO?> GetBiddingAsync(Guid biddingId);

        Task<IEnumerable<BiddingAuctionDTO>?> GetBiddingsAsync(Guid? ownerId, int? skip = 0, int? take = 10);
    }
}
