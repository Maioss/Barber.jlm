using Infrastructure.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<IQueryable<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task<Booking> CreateAsync(Booking booking);
        Task<Booking> UpdateAsync(int id, Booking booking);
        Task<bool> DeleteAsync(int id);
    }
}