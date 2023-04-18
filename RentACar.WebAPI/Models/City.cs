namespace RentACar.WebAPI.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}