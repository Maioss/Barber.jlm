using Infrastructure.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IBarberRepository
    {
        Task<IQueryable<Barber>> GetAllAsync();
        Task<Barber?> GetByIdAsync(int id);
        Task<Barber> CreateAsync(Barber barber);
        Task<Barber> UpdateAsync(int id, Barber barber);
        Task<bool> DeleteAsync(int id);
    }
}