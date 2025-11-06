using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Services
{
    public class BarberService : IBarberService
    {
        public IBarberRepository BarberRepository { get; set; }

        public BarberService(IBarberRepository barberRepository)
        {
            BarberRepository = barberRepository;
        }

        public async Task<Barber> CreateBarber(Barber barber)
        {
            if (barber == null)
            {
                throw new ArgumentNullException(nameof(barber));
            }

            if (string.IsNullOrEmpty(barber.Name))
            {
                throw new ArgumentException("Barber name cannot be null or empty");
            }

            var newBarber = await BarberRepository.CreateAsync(barber);
            return newBarber;
        }

        public async Task<bool> DeleteBarber(int id)
        {
            var result = await BarberRepository.DeleteAsync(id);
            return result;
        }

        public async Task<IEnumerable<Barber>> GetAllBarbers()
        {
            IQueryable<Barber> barbers = await BarberRepository.GetAllAsync();
            barbers = barbers.Where(b => b != null);
            return barbers.ToList();
        }

        public Task<Barber> GetBarberById(int id)
        {
            var barber = BarberRepository.GetByIdAsync(id);
            return barber;
        }

        public Task<Barber> UpdateBarber(int id, Barber barber)
        {
            var updatedBarber = BarberRepository.UpdateAsync(id, barber);
            return updatedBarber;
        }
    }
}