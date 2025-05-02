using LiveAuction.Biddings.Models;
using LiveAuction.Biddings.Repositories;
using LiveAuction.Common.DTO;

namespace LiveAuction.Biddings.Services.MongoDbService
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IBiddingRepository _biddingRepository;

        public MongoDbService(IBiddingRepository biddingRepository)
        {
            _biddingRepository = biddingRepository;
        }

        public async Task CreateBiddingAsync(BiddingAuctionDTO bidding)
        {
            var mongoBidding = new Bidding().FromDTO(bidding);

            if (mongoBidding == null)
            {
                return;
            }

            await _biddingRepository.CreateBiddingAsync(mongoBidding);
        }

        public async Task<BiddingAuctionDTO?> GetBiddingAsync(Guid biddingId)
        {
            var result = await _biddingRepository.GetBiddingAsync(biddingId);

            if (result == null)
            {
                return null;
            }

            return result.ToDTO();
        }

        public async Task<List<BiddingAuctionDTO>?> GetBiddingsAsync(Guid? ownerId, int? skip = 0, int? take = 10)
        {
            var result = await _biddingRepository.GetBiddingsAsync(ownerId, skip, take);

            return result?.Select(b => b.ToDTO()).ToList();
        }

        public async Task UpdateBiddingsAsync(Guid auctionId)
        {
            await _biddingRepository.UpdateBiddingsAsync(auctionId);
        }
    }
}
