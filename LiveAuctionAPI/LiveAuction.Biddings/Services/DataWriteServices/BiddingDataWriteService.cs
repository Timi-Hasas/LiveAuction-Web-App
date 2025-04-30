using LiveAuction.Biddings.Services.MongoDbService;
using LiveAuction.Common.DTO;

namespace LiveAuction.Biddings.Services.DataWriteServices
{
    public class BiddingDataWriteService : IBiddingDataWriteService
    {
        private readonly IMongoDbService _mongoDbService;

        public BiddingDataWriteService(IMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task CreateBiddingAsync(BiddingAuctionDTO bidding)
        {
            if (bidding?.Auction == null)
            {
                throw new ArgumentException("Invalid bidding");
            }

            await _mongoDbService.CreateBiddingAsync(bidding);
        }

        public async Task UpdateBiddingsAsync(Guid auctionId)
        {
            await _mongoDbService.UpdateBiddingsAsync(auctionId);
        }
    }
}
