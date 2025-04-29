using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.DataReadServices
{
    public interface IAuctionDataReadService
    {
        Task<AuctionBiddingDTO?> GetAuctionAsync(Guid auctionId);

        Task<List<AuctionBiddingDTO>?> GetAuctionsAsync();
    }
}
