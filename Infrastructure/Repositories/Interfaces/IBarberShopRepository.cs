using Infrastructure.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IBarberShopRepository
    {
        Task<IQueryable<BarberShop>> GetAllAsync();
        Task<BarberShop?> GetByIdAsync(int id);
        Task<BarberShop> CreateAsync(BarberShop barberShop);
        Task<BarberShop> UpdateAsync(int id, BarberShop barberShop);
        Task<bool> DeleteAsync(int id);
    }
}