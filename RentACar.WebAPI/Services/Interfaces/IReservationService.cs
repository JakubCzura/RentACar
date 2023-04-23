using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;

namespace RentACar.WebAPI.Services.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<Reservation> GetAsync(int id);
        Task CreateAsync(MakeReservationDto user);
        Task UpdateAsync(Reservation user);
        Task DeleteAsync(int id);
    }
}
