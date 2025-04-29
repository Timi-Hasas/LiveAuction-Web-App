using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.DataWriteServices
{
    public interface IAuctionDataWriteService
    {

        Task CreateAuctionAsync(AuctionDTO auction);

        Task UpdateAuctionAsync(AuctionDTO auction);

        Task DeleteAuctionAsync(Guid auctionId);
    }
}
