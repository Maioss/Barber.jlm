using Infrastructure.Entities;

namespace Infrastructure.Services.Interfaces
{
    public interface IBarberService
    {
        Task<Barber> CreateBarber(Barber barber);
        Task<bool> DeleteBarber(int id);
        Task<IEnumerable<Barber>> GetAllBarbers();
        Task<Barber> GetBarberById(int id);
        Task<Barber> UpdateBarber(int id, Barber barber);
    }
}