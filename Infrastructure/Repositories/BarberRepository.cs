using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BarberRepository : IBarberRepository
    {
        public PostgreSQLContext Context { get; set; }

        public BarberRepository(PostgreSQLContext context)
        {
            Context = context;
        }

        public async Task<Barber> CreateAsync(Barber barber)
        {
            await Context.Barbers.AddAsync(barber);
            await Context.SaveChangesAsync();
            return barber;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var barber = await GetByIdAsync(id);
            if (barber == null) return false;
            Context.Barbers.Remove(barber);
            await Context.SaveChangesAsync();
            return true;
        }

        public Task<IQueryable<Barber>> GetAllAsync()
        {
            var barbers = Context.Barbers.AsQueryable();
            return Task.FromResult(barbers);
        }

        public async Task<Barber?> GetByIdAsync(int id)
        {
            var barber = await Context.Barbers
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            return barber;
        }

        public async Task<Barber> UpdateAsync(int id, Barber barber)
        {
            barber.Id = id;
            Context.Entry(barber).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return barber;
        }
    }
}