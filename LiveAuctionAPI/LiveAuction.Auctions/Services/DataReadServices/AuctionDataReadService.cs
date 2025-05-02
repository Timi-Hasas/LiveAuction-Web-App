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

        public async Task<AuctionBiddingDTO?> GetAuctionAsync(Guid auctionId)
        {
            return await _mongoDbService.GetAuctionAsync(auctionId);
        }

        public async Task<List<AuctionBiddingDTO>?> GetAuctionsAsync(Guid? ownerId, int? skip = 0, int? take = 10)
        {
            skip ??= 0;
            take ??= 10;

            return await _mongoDbService.GetAuctionsAsync(ownerId, skip, take);
        }
    }
}
