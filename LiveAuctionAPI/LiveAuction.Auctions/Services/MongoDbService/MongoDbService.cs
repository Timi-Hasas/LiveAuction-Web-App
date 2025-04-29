using LiveAuction.Auctions.Models;
using LiveAuction.Auctions.Repositories;
using LiveAuction.Common.DTO;

namespace LiveAuction.Auctions.Services.MongoDbService
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IAuctionRepository _auctionRepository;

        public MongoDbService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task CreateAuctionAsync(AuctionBiddingDTO auction)
        {
            var mongoAuction = new Auction().FromDTO(auction);

            if (mongoAuction == null)
            {
                return;
            }

            await _auctionRepository.CreateAuctionAsync(mongoAuction);
        }

        public async Task DeleteAuctionAsync(Guid auctionId)
        {
            await _auctionRepository.DeleteAuctionAsync(auctionId);
        }

        public async Task<AuctionBiddingDTO?> GetAuctionAsync(Guid auctionId)
        {
            var auction = await _auctionRepository.GetAuctionAsync(auctionId);

            if (auction == null)
            {
                return null;
            }

            return auction.ToDTO();
        }

        public async Task<List<AuctionBiddingDTO>?> GetAuctionsAsync()
        {
            var auctions = await _auctionRepository.GetAuctionsAsync();

            var result = auctions.Select(a => a.ToDTO()).ToList();

            return result;
        }

        public async Task UpdateAuctionAsync(AuctionBiddingDTO auction)
        {
            var mongoAuction = new Auction().FromDTO(auction);

            if (mongoAuction == null)
            {
                return;
            }

            await _auctionRepository.UpdateAuctionAsync(mongoAuction);
        }
    }
}
