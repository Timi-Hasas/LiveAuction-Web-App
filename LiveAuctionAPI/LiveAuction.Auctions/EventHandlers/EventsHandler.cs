using LiveAuction.Auctions.Services.DataWriteServices;
using LiveAuction.Common.Events.AuctionEvents;
using LiveAuction.Common.Events.BiddingEvents;
using MassTransit;

namespace LiveAuction.Auctions.EventHandlers
{
    public class EventsHandler : IEventsHandler
    {
        private readonly IAuctionDataWriteService _auctionService;

        public EventsHandler(IAuctionDataWriteService auctionService)
        {
            _auctionService = auctionService;
        }

        public async Task Consume(ConsumeContext<AuctionCreated> context)
        {
            await _auctionService.CreateAuctionAsync(context.Message.Auction);
        }

        public async Task Consume(ConsumeContext<AuctionUpdated> context)
        {
            await _auctionService.UpdateAuctionAsync(context.Message.Auction);
        }

        public async Task Consume(ConsumeContext<AuctionDeleted> context)
        {
            await _auctionService.DeleteAuctionAsync(context.Message.AuctionId);
        }

        public async Task Consume(ConsumeContext<BiddingPlaced> context)
        {
            throw new NotImplementedException();
        }
    }
}
