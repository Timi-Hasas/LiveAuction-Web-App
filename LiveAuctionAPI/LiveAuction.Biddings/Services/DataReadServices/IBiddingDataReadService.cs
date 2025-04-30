using LiveAuction.Common.DTO;

namespace LiveAuction.Biddings.Services.DataReadServices
{
    public interface IBiddingDataReadService
    {
        Task<BiddingAuctionDTO?> GetBiddingAsync(Guid biddingId);

        Task<List<BiddingAuctionDTO>?> GetBiddingsAsync();
    }
}
