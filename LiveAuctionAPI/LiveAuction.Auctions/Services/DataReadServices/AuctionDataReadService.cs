using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.DataReadServices
{
    public class AuctionDataReadService : IAuctionDataReadService
    {
        private readonly IAuctionDataReadService _auctionService;

        public AuctionDataReadService(IAuctionDataReadService auctionService)
        {
            _auctionService = auctionService;
        }

        public async Task<AuctionDTO?> GetAuctionAsync(Guid auctionId)
        {
            return await _auctionService.GetAuctionAsync(auctionId);
        }

        public async Task<List<AuctionDTO>?> GetAuctionsAsync()
        {
            return await _auctionService.GetAuctionsAsync();
        }
    }
}
