namespace TestDrivenHotel.DAL
{
    //public List<Booking>? Bookings
    public class RoomModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int MaxNumberOfGuests { get; set; }
        public bool Seaview { get; set; }
        public bool Balcony { get; set; }

    }
}
