using LiveAuction.Common.DTO;
using LiveAuction.Common.Events.UserEvents;
using LiveAuction.Common.Helpers.Exceptions;
using LiveAuction.Gateway.Services.Clients.UserClient;
using LiveAuction.Gateway.Services.Services.Interfaces;
using MassTransit;
using BCryptNet = BCrypt.Net.BCrypt;

namespace LiveAuction.Gateway.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserClient _userClient;
        private readonly IBus _bus;

        public UserService(IUserClient userClient, IBus bus)
        {
            _userClient = userClient;
            _bus = bus;
        }
        public async Task CreateUserAsync(UserConfidentialDTO user)
        {
            var conflictingUser = _userClient.GetUserByEmailAsync(user.Email);
            if (conflictingUser != null)
            {
                throw new AppException("An user with this email already exists");
            }

            user.Password = BCryptNet.HashPassword(user.Password).ToString();

            var userCreated = new UserCreated
            {
                User = user
            };

            await _bus.Publish(userCreated);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var userDeleted = new UserDeleted
            {
                UserId = userId
            };

            await _bus.Publish(userDeleted);
        }

        public async Task<UserConfidentialDTO?> GetUserAsync(Guid userId)
        {
            return await _userClient.GetUserAsync(userId);
        }

        public async Task<UserConfidentialDTO?> GetUserByEmailAsync(string email)
        {
            return await _userClient.GetUserByEmailAsync(email);
        }

        public async Task<IEnumerable<UserConfidentialDTO>?> GetUsersAsync()
        {
            return await _userClient.GetUsersAsync();
        }

        public async Task UpdateUserAsync(UserConfidentialDTO user)
        {
            var conflictingUser = _userClient.GetUserByEmailAsync(user.Email);
            if (conflictingUser != null)
            {
                throw new ArgumentException("An user with this email already exists");
            }

            user.Password = BCryptNet.HashPassword(user.Password).ToString();

            var userUpdated = new UserUpdated
            {
                User = user
            };

            await _bus.Publish(userUpdated);
        }
    }
}
