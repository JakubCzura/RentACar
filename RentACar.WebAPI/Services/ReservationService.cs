using RentACar.WebAPI.Helper;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class ReservationService : CrudService<Reservation>, IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IPickupLocationService _pickupLocationService;
        private readonly IDropoffLocationService _dropoffLocationService;
        private readonly ICarService _carService;
        private readonly IUserService _userService;

        public ReservationService(IReservationRepository reservationRepository, IPickupLocationService pickupLocationService, IDropoffLocationService dropoffLocationService, ICarService carService, IUserService userService) : base(reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _pickupLocationService = pickupLocationService;
            _dropoffLocationService = dropoffLocationService;
            _carService = carService;
            _userService = userService;
        }

        public async Task CreateAsync(MakeReservationDto dto)
        {
            Car car = await _carService.GetAsync(dto.CarId);
            car.IsAvailable = false;
            Reservation reservation = new()
            {
                StartDate = dto.StartDate.Date,
                EndDate = dto.EndDate.Date,
                PickupLocation = await _pickupLocationService.GetAsync(dto.PickupLocationId),
                DropoffLocation = await _dropoffLocationService.GetAsync(dto.DropoffLocationId),
                Car = car,
                TotalCost = TotalCostCalculation.Calculate(dto.StartDate, dto.EndDate, car.DailyRate),
                User = await _userService.GetAsync(dto.UserId)
            };
            await _carService.UpdateAsync(car);
            await _reservationRepository.CreateAsync(reservation);
        }
    }
}