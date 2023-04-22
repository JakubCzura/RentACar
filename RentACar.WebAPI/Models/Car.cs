namespace RentACar.WebAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string PlateNumber { get; set; } = string.Empty;
        public decimal DailyRate { get; set; }
        public string Kind { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;

        public ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();
    }
}