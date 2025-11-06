using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public PostgreSQLContext Context { get; set; }

        public UserRepository(PostgreSQLContext context)
        {
            Context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null) return false;
            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        public Task<IQueryable<User>> GetAllAsync()
        {
            var users = Context.Users.AsQueryable();
            return Task.FromResult(users);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await Context.Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            user.Id = id;
            Context.Entry(user).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return user;
        }
    }
}