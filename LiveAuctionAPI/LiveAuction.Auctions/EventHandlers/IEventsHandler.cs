using LiveAuction.Common.Events.AuctionEvents;
using LiveAuction.Common.Events.BidEvents;
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
