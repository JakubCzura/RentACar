namespace RentACar.WebAPI.Models
{
    public class PickupLocation
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public int ParkingSpaces { get; set; }

        public int ParkedCars { get; set; }

        public City City { get; set; } = new();

        public ICollection<Reservation>? Reservations{ get; set; } = new List<Reservation>();
    }
}