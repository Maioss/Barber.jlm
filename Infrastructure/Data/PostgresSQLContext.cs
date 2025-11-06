using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;

namespace Infrastructure.Data
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //Tablas
        public DbSet<User> Users { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<BarberShop> Barberias { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
