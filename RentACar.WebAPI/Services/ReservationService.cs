using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationService _reservationService;

        public ReservationService(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _reservationService.GetAllAsync();
        }

        public async Task<Reservation> GetAsync(int id)
        {
            return await _reservationService.GetAsync(id);
        }

        public async Task CreateAsync(Reservation reservation)
        {
            await _reservationService.CreateAsync(reservation);
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            await _reservationService.UpdateAsync(reservation);
        }

        public async Task DeleteAsync(int id)
        {
            await _reservationService.DeleteAsync(id);
        }
    }
}
