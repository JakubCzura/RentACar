namespace RentACar.WebAPI.Models.Dtos
{
    public class GetTotalCostDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DailyRate { get; set; }
    }
}