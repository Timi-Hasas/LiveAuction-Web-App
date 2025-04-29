using LiveAuction.Common.Events.UserEvents;
using MassTransit;

namespace LiveAuction.Users.EventHandlers
{
    public interface IEventsHandler :
        IConsumer<UserCreated>,
        IConsumer<UserUpdated>,
        IConsumer<UserDeleted>
    {
    }
}
