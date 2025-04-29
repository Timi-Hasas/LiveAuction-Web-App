using LiveAuction.Auctions.Services.MongoDbService;
using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.DataWriteServices
{
    public class AuctionDataWriteService : IAuctionDataWriteService
    {
        private readonly IMongoDbService _mongoDbService;

        public AuctionDataWriteService(IMongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task CreateAuctionAsync(AuctionDTO auction)
        {
            await _mongoDbService.CreateAuctionAsync(auction);
        }

        public async Task DeleteAuctionAsync(Guid auctionId)
        {
            await _mongoDbService.DeleteAuctionAsync(auctionId);
        }

        public async Task UpdateAuctionAsync(AuctionDTO auction)
        {
            await _mongoDbService.UpdateAuctionAsync(auction);
        }
    }
}
