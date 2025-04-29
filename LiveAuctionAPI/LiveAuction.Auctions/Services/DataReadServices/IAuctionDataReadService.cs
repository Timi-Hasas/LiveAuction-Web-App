using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.DataReadServices
{
    public interface IAuctionDataReadService
    {
        Task<AuctionDTO?> GetAuctionAsync(Guid auctionId);

        Task<List<AuctionDTO>?> GetAuctionsAsync();
    }
}
