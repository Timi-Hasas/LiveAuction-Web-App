using LiveAuction.Common.DTO;

namespace LiveAuction.Biddings.Services.DataWriteServices
{
    public interface IBiddingDataWriteService
    {
        Task CreateBiddingAsync(BiddingAuctionDTO bidding);

        Task UpdateBiddingsAsync(Guid auctionId);
    }
}
