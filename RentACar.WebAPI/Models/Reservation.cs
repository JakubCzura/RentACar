namespace RentACar.WebAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalCost { get; set; }

        public Car Car { get; set; } = new();
    }
}