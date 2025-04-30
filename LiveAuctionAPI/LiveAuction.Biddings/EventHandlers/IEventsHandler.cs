using LiveAuction.Common.Events.AuctionEvents;
using LiveAuction.Common.Events.BiddingEvents;
using MassTransit;

namespace LiveAuction.Biddings.EventHandlers
{
    public interface IEventsHandler : 
        IConsumer<BiddingPlaced>,
        IConsumer<AuctionCompleted>
    {
    }
}
