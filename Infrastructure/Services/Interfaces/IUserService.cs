using Infrastructure.Entities;

namespace Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int id, User user);
    }
}