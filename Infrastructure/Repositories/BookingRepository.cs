using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public PostgreSQLContext Context { get; set; }

        public BookingRepository(PostgreSQLContext context)
        {
            Context = context;
        }

        public async Task<Booking> CreateAsync(Booking booking)
        {
            await Context.Bookings.AddAsync(booking);
            await Context.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var booking = await GetByIdAsync(id);
            if (booking == null) return false;
            Context.Bookings.Remove(booking);
            await Context.SaveChangesAsync();
            return true;
        }

        public Task<IQueryable<Booking>> GetAllAsync()
        {
            var bookings = Context.Bookings.AsQueryable();
            return Task.FromResult(bookings);
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            var booking = await Context.Bookings
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            return booking;
        }

        public async Task<Booking> UpdateAsync(int id, Booking booking)
        {
            booking.Id = id;
            Context.Entry(booking).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return booking;
        }
    }
}