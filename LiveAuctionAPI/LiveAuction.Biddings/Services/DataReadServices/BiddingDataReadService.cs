using LiveAuction.Biddings.Services.MongoDbService;
using LiveAuction.Common.DTO;

namespace LiveAuction.Biddings.Services.DataReadServices
{
    public class BiddingDataReadService : IBiddingDataReadService
    {
        private readonly IMongoDbService _mongoDbService;

        public BiddingDataReadService(IMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task<BiddingAuctionDTO?> GetBiddingAsync(Guid biddingId)
        {
            return await _mongoDbService.GetBiddingAsync(biddingId);
        }

        public async Task<List<BiddingAuctionDTO>?> GetBiddingsAsync()
        {
            return await _mongoDbService.GetBiddingsAsync();
        }
    }
}
