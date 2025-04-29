using LiveAuction.Common.Events.AuctionEvents;
using LiveAuction.Common.Events.BiddingEvents;
using MassTransit;

namespace LiveAuction.Auctions.EventHandlers
{
    public interface IEventsHandler:
        IConsumer<AuctionCreated>,
        IConsumer<AuctionUpdated>,
        IConsumer<AuctionDeleted>,
        IConsumer<BiddingPlaced>
    {
    }
}
