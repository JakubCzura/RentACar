namespace RentACar.WebAPI.Models
{
    public class ParkingPlace
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = true;
    }
}