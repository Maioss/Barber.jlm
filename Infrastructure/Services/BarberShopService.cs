using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Services
{
    public class BarberShopService : IBarberShopService
    {
        public IBarberShopRepository BarberShopRepository { get; set; }

        public BarberShopService(IBarberShopRepository barberShopRepository)
        {
            BarberShopRepository = barberShopRepository;
        }

        public async Task<BarberShop> CreateBarberShop(BarberShop barberShop)
        {
            if (barberShop == null)
            {
                throw new ArgumentNullException(nameof(barberShop));
            }

            if (string.IsNullOrEmpty(barberShop.Name))
            {
                throw new ArgumentException("BarberShop name cannot be null or empty");
            }

            var newBarberShop = await BarberShopRepository.CreateAsync(barberShop);
            return newBarberShop;
        }

        public async Task<bool> DeleteBarberShop(int id)
        {
            var result = await BarberShopRepository.DeleteAsync(id);
            return result;
        }

        public async Task<IEnumerable<BarberShop>> GetAllBarberShops()
        {
            IQueryable<BarberShop> barberShops = await BarberShopRepository.GetAllAsync();
            barberShops = barberShops.Where(bs => bs != null);
            return barberShops.ToList();
        }

        public Task<BarberShop> GetBarberShopById(int id)
        {
            var barberShop = BarberShopRepository.GetByIdAsync(id);
            return barberShop;
        }

        public Task<BarberShop> UpdateBarberShop(int id, BarberShop barberShop)
        {
            var updatedBarberShop = BarberShopRepository.UpdateAsync(id, barberShop);
            return updatedBarberShop;
        }
    }
}