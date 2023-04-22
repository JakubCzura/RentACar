using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation> GetAsync(int id)
        {
            return await _reservationRepository.GetAsync(id);
        }

        public async Task CreateAsync(Reservation reservation)
        {
            await _reservationRepository.CreateAsync(reservation);
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            await _reservationRepository.UpdateAsync(reservation);
        }

        public async Task DeleteAsync(int id)
        {
            await _reservationRepository.DeleteAsync(id);
        }
    }
}
