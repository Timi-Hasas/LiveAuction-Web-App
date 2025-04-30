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
            auction.CurrentHighestBidding.IsActive = false;

            foreach (var bidding in auction.Biddings ?? new List<BiddingDTO>())
            {
                bidding.IsActive = false;
            }

            await _mongoDbService.UpdateAuctionAsync(auction);
        }

        public async Task PlaceAuctionBiddingAsync(BiddingAuctionDTO bidding)
        {
            if (bidding?.Auction == null)
            {
                throw new ArgumentException("Invalid bidding");
            }

            var auction = await _mongoDbService.GetAuctionAsync(bidding.Auction.Id);

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

            var biddingDto = new BiddingDTO
            {
                Id = bidding.Id,
                Amount = bidding.Amount,
                AuctionId = bidding.Auction.Id,
                IsActive = bidding.IsActive,
                Owner = bidding.Owner,
                Timestamp = bidding.Timestamp
            };

            auction.CurrentHighestBidding = biddingDto;

            auction.Biddings ??= new List<BiddingDTO>();
            auction.Biddings.Add(biddingDto);

            await _mongoDbService.UpdateAuctionAsync(auction);
        }
    }
}
