using LiveAuction.Common.DTO;
using LiveAuction.Common.Events.AuctionEvents;
using LiveAuction.Gateway.Services.Clients.AuctionClient;
using LiveAuction.Gateway.Services.Services.Interfaces;
using MassTransit;

namespace LiveAuction.Gateway.Services.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionClient _auctionClient;
        private readonly IBus _bus;

        public AuctionService(IAuctionClient auctionClient, IBus bus)
        {
            _auctionClient = auctionClient;
            _bus = bus;
        }

        public async Task CreateAuctionAsync(AuctionDTO auction)
        {
            var auctionCreated = new AuctionCreated
            {
                Auction = auction
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
            var auctionUpdated = new AuctionUpdated
            {
                Auction = auction
            };

            await _bus.Publish(auctionUpdated);
        }

        public async Task<AuctionDTO?> GetAuctionAsync(Guid auctionId)
        {
            return await _auctionClient.GetAuctionAsync(auctionId);
        }

        public async Task<IEnumerable<AuctionDTO>?> GetAuctionsAsync()
        {
            return await _auctionClient.GetAuctionsAsync();
        }
    }
}
