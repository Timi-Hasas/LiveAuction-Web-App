using LiveAuction.Common.DTO;
using LiveAuction.Common.Events.AuctionEvents;
using LiveAuction.Common.Helpers.Exceptions;
using LiveAuction.Gateway.Services.Clients.AuctionClient;
using LiveAuction.Gateway.Services.Services.Interfaces;
using MassTransit;

namespace LiveAuction.Gateway.Services.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionClient _auctionClient;
        private readonly IUserService _userService;
        private readonly IBus _bus;

        public AuctionService(IAuctionClient auctionClient, IUserService userService, IBus bus)
        {
            _auctionClient = auctionClient;
            _userService = userService;
            _bus = bus;
        }

        public async Task CreateAuctionAsync(AuctionDTO auction)
        {
            var owner = await _userService.GetUserAsync(auction.OwnerId);

            if (owner== null)
            {
                throw new AppException("Invalid auction owner");
            }

            var biddingAuction = new AuctionBiddingDTO
            {
                Id = auction.Id,
                AuctionedItemName = auction.AuctionedItemName,
                AuctionTimeInMinutes = auction.AuctionTimeInMinutes,
                Description = auction.Description,
                MinimumBid = auction.MinimumBid,
                Name = auction.Name,
                StartingPrice = auction.StartingPrice,
                Timestamp = auction.Timestamp,
                Owner = owner
            };

            var auctionCreated = new AuctionCreated
            {
                Auction = biddingAuction
            };

            await _bus.Publish(auctionCreated);
        }

        public async Task DeleteAuctionAsync(Guid auctionId)
        {
            var auctionDeleted = new AuctionDeleted
            {
                AuctionId = auctionId
            };

            await _bus.Publish(auctionDeleted);
        }

        public async Task UpdateAuctionAsync(AuctionDTO auction)
        {
            var owner = await _userService.GetUserAsync(auction.OwnerId);

            if (owner == null)
            {
                throw new AppException("Invalid auction owner");
            }

            var biddingAuction = new AuctionBiddingDTO
            {
                Id = auction.Id,
                AuctionedItemName = auction.AuctionedItemName,
                AuctionTimeInMinutes = auction.AuctionTimeInMinutes,
                Description = auction.Description,
                MinimumBid = auction.MinimumBid,
                Name = auction.Name,
                StartingPrice = auction.StartingPrice,
                Timestamp = auction.Timestamp,
                Owner = owner
            };

            var auctionUpdated = new AuctionUpdated
            {
                Auction = biddingAuction
            };

            await _bus.Publish(auctionUpdated);
        }

        public async Task CompleteAuctionAsync(Guid auctionId)
        {
            var auctionCompleted = new AuctionCompleted
            {
                AuctionId = auctionId
            };

            await _bus.Publish(auctionCompleted);
        }

        public async Task<AuctionBiddingDTO?> GetAuctionAsync(Guid auctionId)
        {
            return await _auctionClient.GetAuctionAsync(auctionId);
        }

        public async Task<IEnumerable<AuctionBiddingDTO>?> GetAuctionsAsync(Guid? ownerId, int? skip = 0, int? take = 10)
        {
            skip ??= 0;
            take ??= 10;

            return await _auctionClient.GetAuctionsAsync(ownerId, skip, take);
        }
    }
}
