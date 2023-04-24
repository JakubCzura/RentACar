using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class DropoffLocationService : CrudService<DropoffLocation>, IDropoffLocationService
    {
        public DropoffLocationService(IDropoffLocationRepository dropoffLocationRepository) : base(dropoffLocationRepository)
        {
        }
    }
}