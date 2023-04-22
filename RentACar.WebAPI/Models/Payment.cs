namespace RentACar.WebAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Reservation Reservation { get; set; } = new();
        public int ReservationId { get; set; }
    }
}
