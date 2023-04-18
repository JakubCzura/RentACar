namespace RentACar.WebAPI.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public ICollection<ParkingPlace> ParkingPlaces { get; set; } = new List<ParkingPlace>();
    }
}