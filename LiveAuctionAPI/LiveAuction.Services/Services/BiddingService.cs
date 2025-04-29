using LiveAuction.Common.DTO;
using LiveAuction.Common.Events.BiddingEvents;
using LiveAuction.Common.Helpers.Exceptions;
using LiveAuction.Gateway.Services.Services.Interfaces;
using MassTransit;

namespace LiveAuction.Gateway.Services.Services
{
    public class BiddingService : IBiddingService
    {
        private readonly IUserService _userService;
        private readonly IBus _bus;

        public BiddingService(IUserService userService, IBus bus)
        {
            _userService = userService;
            _bus = bus;
        }

        public async Task PlaceBiddingAsync(PlaceBiddingDTO bidding)
        {
            var owner = await _userService.GetUserAsync(bidding.OwnerId);

            if (owner == null)
            {
                throw new AppException("Invalid auction owner");
            }

            var biddingPlaced = new BiddingPlaced
            {
                Bidding = new BiddingDTO
                {
                    Id = bidding.Id == Guid.Empty 
                        ? Guid.NewGuid() 
                        : bidding.Id,
                    Amount = bidding.Amount,
                    AuctionId = bidding.AuctionId,
                    Timestamp = bidding.Timestamp,
                    IsActive = true,
                    Owner = owner
                },
            };

            await _bus.Publish(biddingPlaced);
        }
    }
}
