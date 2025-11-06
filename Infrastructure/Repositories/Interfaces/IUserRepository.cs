using Infrastructure.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IQueryable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
    }
}