namespace RentACar.WebAPI.Models.Dtos
{
    public class SummaryDto
    {
        public SummaryDto(DateTime startDate, DateTime endDate, int carId, int pickupLocationId, int dropoffLocationId, decimal totalCost)
        {
            StartDate = startDate;
            EndDate = endDate;
            CarId = carId;
            PickupLocationId = pickupLocationId;
            DropoffLocationId = dropoffLocationId;
            TotalCost = totalCost;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CarId { get; set; }
        public int PickupLocationId { get; set; }
        public int DropoffLocationId { get; set; }
        public decimal TotalCost { get; set; }
    }
}