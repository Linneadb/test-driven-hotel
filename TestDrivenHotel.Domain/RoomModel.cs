namespace TestDrivenHotel.Domain
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int MaxNumberOfGuests { get; set; }
        public List<Booking>? Bookings { get; set; }
    }

    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Created { get; set; }
        public string? Comment { get; set; }
    }


}
