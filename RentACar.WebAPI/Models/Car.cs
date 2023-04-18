namespace RentACar.WebAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int ManufactureYear { get; set; }
        public decimal DailyRate { get; set; }
        public string Kind { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public ParkingPlace ParkingPlace { get; set; } = new();
    }
}