using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        public IBookingRepository BookingRepository { get; set; }

        public BookingService(IBookingRepository bookingRepository)
        {
            BookingRepository = bookingRepository;
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentNullException(nameof(booking));
            }

            if (booking.StartDate >= booking.EndDate)
            {
                throw new ArgumentException("Start date must be before end date");
            }

            var newBooking = await BookingRepository.CreateAsync(booking);
            return newBooking;
        }

        public async Task<bool> DeleteBooking(int id)
        {
            var result = await BookingRepository.DeleteAsync(id);
            return result;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            IQueryable<Booking> bookings = await BookingRepository.GetAllAsync();
            bookings = bookings.Where(b => b != null);
            return bookings.ToList();
        }

        public Task<Booking> GetBookingById(int id)
        {
            var booking = BookingRepository.GetByIdAsync(id);
            return booking;
        }

        public Task<Booking> UpdateBooking(int id, Booking booking)
        {
            var updatedBooking = BookingRepository.UpdateAsync(id, booking);
            return updatedBooking;
        }
    }
}