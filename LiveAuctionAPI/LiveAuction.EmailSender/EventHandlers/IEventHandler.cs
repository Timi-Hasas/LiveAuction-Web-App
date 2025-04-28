using LiveAuction.Common.Events.UserEvents;
using MassTransit;

namespace LiveAuction.Notifications.EventHandlers
{
    public interface IEventHandler :
        IConsumer<UserCreated>,
        IConsumer<UserDeleted>
    {
    }
}
