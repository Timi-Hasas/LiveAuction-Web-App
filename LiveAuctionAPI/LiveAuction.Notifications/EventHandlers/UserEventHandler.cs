using LiveAuction.Common.Events.UserEvents;
using MassTransit;

namespace LiveAuction.Notifications.EventHandlers
{
    public class UserEventHandler : IEventHandler
    {
        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            throw new NotImplementedException();
        }

        public Task Consume(ConsumeContext<UserDeleted> context)
        {
            throw new NotImplementedException();
        }
    }
}
