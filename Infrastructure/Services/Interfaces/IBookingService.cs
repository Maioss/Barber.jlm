using Infrastructure.Entities;

namespace Infrastructure.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> CreateBooking(Booking booking);
        Task<bool> DeleteBooking(int id);
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<Booking> GetBookingById(int id);
        Task<Booking> UpdateBooking(int id, Booking booking);
    }
}