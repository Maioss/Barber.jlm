using Infrastructure.Entities;

namespace Infrastructure.Services.Interfaces
{
    public interface IBarberShopService
    {
        Task<BarberShop> CreateBarberShop(BarberShop barberShop);
        Task<bool> DeleteBarberShop(int id);
        Task<IEnumerable<BarberShop>> GetAllBarberShops();
        Task<BarberShop> GetBarberShopById(int id);
        Task<BarberShop> UpdateBarberShop(int id, BarberShop barberShop);
    }
}