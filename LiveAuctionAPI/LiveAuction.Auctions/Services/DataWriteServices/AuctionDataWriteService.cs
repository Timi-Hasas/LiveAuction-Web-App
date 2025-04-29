using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.DataWriteServices
{
    public class AuctionDataWriteService : IAuctionDataWriteService
    {
        private readonly IAuctionDataWriteService _auctionService;

        public AuctionDataWriteService(IAuctionDataWriteService auctionService)
        {
            _auctionService = auctionService;
        }

        public async Task CreateAuctionAsync(AuctionDTO auction)
        {
            await _auctionService.CreateAuctionAsync(auction);
        }

        public async Task DeleteAuctionAsync(Guid auctionId)
        {
            await _auctionService.DeleteAuctionAsync(auctionId);
        }

        public async Task UpdateAuctionAsync(AuctionDTO auction)
        {
            await _auctionService.UpdateAuctionAsync(auction);
        }
    }
}
