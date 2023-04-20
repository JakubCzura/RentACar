using Microsoft.EntityFrameworkCore;
using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;

namespace RentACar.WebAPI.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RentACarDbContext _rentACarDbContext;

        public ReservationRepository(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _rentACarDbContext.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetAsync(int id)
        {
            return await _rentACarDbContext.Reservations.FindAsync(id) ?? null!;
        }

        public async Task CreateAsync(Reservation reservation)
        {
            await _rentACarDbContext.Reservations.AddAsync(reservation);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _rentACarDbContext.Update(reservation);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = await _rentACarDbContext.Reservations.FindAsync(id);
            _rentACarDbContext.Reservations.Remove(reservation!);
            await _rentACarDbContext.SaveChangesAsync();
        }
    }
}
