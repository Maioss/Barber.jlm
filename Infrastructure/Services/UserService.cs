using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository { get; set; }

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrEmpty(user.Name))
            {
                throw new ArgumentException("User name cannot be null or empty");
            }

            var newUser = await UserRepository.CreateAsync(user);
            return newUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var result = await UserRepository.DeleteAsync(id);
            return result;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            IQueryable<User> users = await UserRepository.GetAllAsync();
            users = users.Where(u => u != null);
            return users.ToList();
        }

        public Task<User> GetUserById(int id)
        {
            var user = UserRepository.GetByIdAsync(id);
            return user;
        }

        public Task<User> UpdateUser(int id, User user)
        {
            var updatedUser = UserRepository.UpdateAsync(id, user);
            return updatedUser;
        }
    }
}