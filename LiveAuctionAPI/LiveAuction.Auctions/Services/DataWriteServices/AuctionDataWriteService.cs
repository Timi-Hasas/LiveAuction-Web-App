using LiveAuction.Auctions.Models;
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

        public async Task CreateAuctionAsync(AuctionBiddingDTO auction)
        {
            await _mongoDbService.CreateAuctionAsync(auction);
        }

        public async Task DeleteAuctionAsync(Guid auctionId)
        {
            await _mongoDbService.DeleteAuctionAsync(auctionId);
        }

        public async Task UpdateAuctionAsync(AuctionBiddingDTO auction)
        {
            await _mongoDbService.UpdateAuctionAsync(auction);
        }

        public async Task CompleteAuctionAsync(Guid auctionId)
        {
            var auction = await _mongoDbService.GetAuctionAsync(auctionId);

            if (auction == null)
            {
                return;
            }

            auction.IsCompleted = true;

            await _mongoDbService.UpdateAuctionAsync(auction);
        }

        public async Task PlaceAuctionBiddingAsync(BiddingDTO bidding)
        {
            var auction = await _mongoDbService.GetAuctionAsync(bidding.AuctionId);

            if (auction == null)
            {
                throw new ArgumentException("Invalid auction");
            }

            if (auction.CurrentHighestBidding?.Amount >= bidding.Amount)
            {
                throw new ArgumentException("Invalid bidding amount");
            }

            if (auction.CurrentHighestBidding?.Owner?.Id == bidding.Owner?.Id)
            {
                throw new ArgumentException("The owner already has the highest bidding amount");
            }

            auction.CurrentHighestBidding = bidding;

            auction.Biddings ??= new List<BiddingDTO>();
            auction.Biddings.Add(bidding);

            await _mongoDbService.UpdateAuctionAsync(auction);
        }
    }
}
