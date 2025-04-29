using LiveAuction.Common.Events.UserEvents;
using LiveAuction.Users.Services.DataWriteServices;
using MassTransit;

namespace LiveAuction.Users.EventHandlers
{
    public class EventsHandler : IEventsHandler

    {
        private readonly IUserDataWriteService _userService;

        public EventsHandler(IUserDataWriteService userService)
        {
            _userService = userService;
        }

        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            await _userService.CreateUserAsync(context.Message.User);
        }

        public async Task Consume(ConsumeContext<UserUpdated> context)
        {
            await _userService.UpdateUserAsync(context.Message.User);
        }

        public async Task Consume(ConsumeContext<UserDeleted> context)
        {
            await _userService.DeleteUserAsync(context.Message.UserId);
        }
    }
}
