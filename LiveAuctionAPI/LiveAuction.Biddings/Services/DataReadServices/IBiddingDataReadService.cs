using LiveAuction.Common.DTO;

namespace LiveAuction.Biddings.Services.DataReadServices
{
    public interface IBiddingDataReadService
    {
        Task<BiddingAuctionDTO?> GetBiddingAsync(Guid biddingId);

        Task<List<BiddingAuctionDTO>?> GetBiddingsAsync(Guid? ownerId, int? skip = 0, int? take = 10);
    }
}
