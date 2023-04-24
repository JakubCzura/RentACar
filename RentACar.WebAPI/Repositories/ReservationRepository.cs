using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;

namespace RentACar.WebAPI.Repositories
{
    public class ReservationRepository : CrudRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(RentACarDbContext rentACarDbContext) : base(rentACarDbContext)
        {
        }
    }
}