using LiveAuction.Common.DTO;
using LiveAuction.Users.Models;
using LiveAuction.Users.Repositories;

namespace LiveAuction.Users.Services.MongoDbService
{
    public class MongoDbService : IMongoDbService
    {
        public readonly IUserRepository _userRepository;
        
        public MongoDbService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(AuthUserDTO user)
        {
            var mongoUser = new User
            {
                Id = user.Id,
                BirthDate = user.BirthDate,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Email = user.Email
            };

            await _userRepository.CreateUserAsync(mongoUser);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<AuthUserDTO?> GetUserAsync(Guid userId)
        {
            var user = await _userRepository.GetUserAsync(userId);

            var result = user == null ? null : new AuthUserDTO
            {
                Id = user.Id,
                BirthDate = user.BirthDate,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Email = user.Email
            };


            return result;
        }

        public async Task<AuthUserDTO?> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            var result = user == null ? null : new AuthUserDTO
            {
                Id = user.Id,
                BirthDate = user.BirthDate,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Email = user.Email
            };

            return result;
        }

        public async Task<List<AuthUserDTO>?> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();

            var result = users?.Select(user => new AuthUserDTO
            {
                Id = user.Id,
                BirthDate = user.BirthDate,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Email = user.Email
            }).ToList();

            return result;  
        }

        public async Task UpdateUserAsync(AuthUserDTO user)
        {
            var mongoUser = new User
            {
                Id = user.Id,
                BirthDate = user.BirthDate,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Email = user.Email
            };

            await _userRepository.UpdateUserAsync(mongoUser);
        }
    }
}
