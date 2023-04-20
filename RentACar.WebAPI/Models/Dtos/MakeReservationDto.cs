namespace RentACar.WebAPI.Models.Dtos
{
    public class MakeReservationDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalCost { get; set; }

        public Car Car { get; set; } = new();
    }
}
