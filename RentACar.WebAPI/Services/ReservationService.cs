using RentACar.WebAPI.Helper;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IPickupLocationService _pickupLocationService;
        private readonly IDropoffLocationService _dropoffLocationService;
        private readonly ICarService _carService;
        private readonly IUserService _userService;

        public ReservationService(IReservationRepository reservationRepository, IPickupLocationService pickupLocationService, IDropoffLocationService dropoffLocationService, ICarService carService, IUserService userService)
        {
            _reservationRepository = reservationRepository;
            _pickupLocationService = pickupLocationService;
            _dropoffLocationService = dropoffLocationService;
            _carService = carService;
            _userService = userService;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation> GetAsync(int id)
        {
            return await _reservationRepository.GetAsync(id);
        }

        public async Task CreateAsync(MakeReservationDto dto)
        {
            Car car = await _carService.GetAsync(dto.CarId);
            car.IsAvailable = false;
            Reservation reservation = new()
            {
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                PickupLocation = await _pickupLocationService.GetAsync(dto.PickupLocationId),
                DropoffLocation = await _dropoffLocationService.GetAsync(dto.DropoffLocationId),
                Car = car,
                TotalCost = TotalCostCalculation.Calculate(dto.StartDate, dto.EndDate, car.DailyRate),
                User = await _userService.GetAsync(dto.UserId)
            };
            await _carService.UpdateAsync(car);
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
