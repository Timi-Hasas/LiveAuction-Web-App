using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.DataReadServices
{
    public interface IAuctionDataReadService
    {
        Task<AuctionBiddingDTO?> GetAuctionAsync(Guid auctionId);

        Task<List<AuctionBiddingDTO>?> GetAuctionsAsync(Guid? ownerId, int? skip = 0, int? take = 10);
    }
}
