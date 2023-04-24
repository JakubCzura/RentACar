using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;

namespace RentACar.WebAPI.Repositories
{
    public class PickupLocationRepository : CrudRepository<PickupLocation>, IPickupLocationRepository
    {
        public PickupLocationRepository(RentACarDbContext rentACarDbContext) : base(rentACarDbContext)
        {
        }
    }
}