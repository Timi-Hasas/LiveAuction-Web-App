using LiveAuction.Auctions.Services.MongoDbService;
using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.DataReadServices
{
    public class AuctionDataReadService : IAuctionDataReadService
    {
        private readonly IMongoDbService _mongoDbService;

        public AuctionDataReadService(IMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task<AuctionDTO?> GetAuctionAsync(Guid auctionId)
        {
            return await _mongoDbService.GetAuctionAsync(auctionId);
        }

        public async Task<List<AuctionDTO>?> GetAuctionsAsync()
        {
            return await _mongoDbService.GetAuctionsAsync();
        }
    }
}
