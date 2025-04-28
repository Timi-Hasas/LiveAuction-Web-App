using LiveAuction.Common.Events.UserEvents;
using MassTransit;

namespace LiveAuction.Users.EventHandlers
{
    public interface IEventHandler :
        IConsumer<UserCreated>,
        IConsumer<UserUpdated>,
        IConsumer<UserDeleted>
    {
    }
}
