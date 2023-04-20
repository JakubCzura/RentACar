using RentACar.WebAPI.Models;

namespace RentACar.WebAPI.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<Reservation> GetAsync(int id);
        Task CreateAsync(Reservation user);
        Task UpdateAsync(Reservation user);
        Task DeleteAsync(int id);
    }
}
