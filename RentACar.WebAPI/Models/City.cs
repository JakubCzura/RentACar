namespace RentACar.WebAPI.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<PickupLocation> Locations { get; set; } = new List<PickupLocation>();
    }
}