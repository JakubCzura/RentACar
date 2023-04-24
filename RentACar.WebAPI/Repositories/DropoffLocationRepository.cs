using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;

namespace RentACar.WebAPI.Repositories
{
    public class DropoffLocationRepository : CrudRepository<DropoffLocation>, IDropoffLocationRepository
    {
        public DropoffLocationRepository(RentACarDbContext rentACarDbContext) : base(rentACarDbContext)
        {
        }
    }
}