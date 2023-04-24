namespace RentACar.WebAPI.Models.Dtos
{
    public class MakeReservationDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int UserId { get; set; }

        public int CarId { get; set; }

        public int PickupLocationId { get; set; }

        public int DropoffLocationId { get; set; }
    }
}