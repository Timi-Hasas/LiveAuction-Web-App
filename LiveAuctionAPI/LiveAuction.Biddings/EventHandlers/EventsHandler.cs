using LiveAuction.Biddings.Services.DataWriteServices;
using LiveAuction.Common.Events.AuctionEvents;
using LiveAuction.Common.Events.BiddingEvents;
using MassTransit;

namespace LiveAuction.Biddings.EventHandlers
{
    public class EventsHandler : IEventsHandler
    {
        private readonly IBiddingDataWriteService _biddingService;

        public EventsHandler(IBiddingDataWriteService biddingService)
        {
            _biddingService = biddingService;
        }

        public async Task Consume(ConsumeContext<BiddingPlaced> context)
        {
            await _biddingService.CreateBiddingAsync(context.Message.Bidding);
        }

        public async Task Consume(ConsumeContext<AuctionCompleted> context)
        {
            await _biddingService.UpdateBiddingsAsync(context.Message.AuctionId);
        }
    }
}
