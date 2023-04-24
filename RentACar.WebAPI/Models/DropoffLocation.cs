namespace RentACar.WebAPI.Models
{
    public class DropoffLocation
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();
    }
}