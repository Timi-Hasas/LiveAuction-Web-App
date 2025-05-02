using LiveAuction.Common.DTO;
using LiveAuction.Common.Events.BiddingEvents;
using LiveAuction.Common.Helpers.Exceptions;
using LiveAuction.Gateway.Services.Clients.BiddingClient;
using LiveAuction.Gateway.Services.Services.Interfaces;
using MassTransit;

namespace LiveAuction.Gateway.Services.Services
{
    public class BiddingService : IBiddingService
    {
        private readonly IUserService _userService;
        private readonly IAuctionService _auctionService;
        private readonly IBiddingClient _biddingClient;
        private readonly IBus _bus;

        public BiddingService(IUserService userService, IAuctionService auctionService, IBiddingClient biddingClient, IBus bus)
        {
            _userService = userService;
            _auctionService = auctionService;
            _biddingClient = biddingClient;
            _bus = bus;
        }

        public async Task<BiddingAuctionDTO?> GetBiddingAsync(Guid biddingId)
        {
            return await _biddingClient.GetBiddingAsync(biddingId);
        }

        public async Task<IEnumerable<BiddingAuctionDTO>?> GetBiddingsAsync(Guid? ownerId, int? skip = 0, int? take = 10)
        {
            skip ??= 0;
            take ??= 10;

            return await _biddingClient.GetBiddingsAsync(ownerId, skip, take);
        }

        public async Task PlaceBiddingAsync(PlaceBiddingDTO bidding)
        {
            var owner = await _userService.GetUserAsync(bidding.OwnerId);
            if (owner == null)
            {
                throw new AppException("Invalid auction owner");
            }

            var auction = await _auctionService.GetAuctionAsync(bidding.AuctionId);
            if (auction == null)
            {
                throw new AppException("Invalid auction");
            }

            var biddingPlaced = new BiddingPlaced
            {
                Bidding = new BiddingAuctionDTO
                {
                    Id = bidding.Id == Guid.Empty 
                        ? Guid.NewGuid() 
                        : bidding.Id,
                    Amount = bidding.Amount,
                    Auction = auction,
                    Timestamp = bidding.Timestamp,
                    IsActive = true,
                    Owner = owner
                },
            };

            await _bus.Publish(biddingPlaced);
        }
    }
}
