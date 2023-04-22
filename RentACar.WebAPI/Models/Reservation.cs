namespace RentACar.WebAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public User User { get; set; } = new();

        public Car Car { get; set; } = new();

        public PickupLocation PickupLocation { get; set; } = new();

        public DropoffLocation DropoffLocation { get; set; } = new();

        public Payment Payment { get; set; } = new();

        public int PaymentId { get; set; }
    }
}