using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BarberShopRepository : IBarberShopRepository
    {
        public PostgreSQLContext Context { get; set; }

        public BarberShopRepository(PostgreSQLContext context)
        {
            Context = context;
        }

        public async Task<BarberShop> CreateAsync(BarberShop barberShop)
        {
            await Context.Barberias.AddAsync(barberShop);
            await Context.SaveChangesAsync();
            return barberShop;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var barberShop = await GetByIdAsync(id);
            if (barberShop == null) return false;
            Context.Barberias.Remove(barberShop);
            await Context.SaveChangesAsync();
            return true;
        }

        public Task<IQueryable<BarberShop>> GetAllAsync()
        {
            var barberShops = Context.Barberias.AsQueryable();
            return Task.FromResult(barberShops);
        }

        public async Task<BarberShop?> GetByIdAsync(int id)
        {
            var barberShop = await Context.Barberias
                .Where(bs => bs.Id == id)
                .FirstOrDefaultAsync();
            return barberShop;
        }

        public async Task<BarberShop> UpdateAsync(int id, BarberShop barberShop)
        {
            barberShop.Id = id;
            Context.Entry(barberShop).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return barberShop;
        }
    }
}