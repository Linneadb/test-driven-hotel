
namespace TestDrivenHotel.DAL.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public int Price { get; set; }
        public int MaxNumberOfGuests { get; set; }
        public bool Seaview { get; set; }
        public bool Balcony { get; set; }

        // Navigation property
        public ICollection<BookingModel>? Bookings { get; set; }
    }
}
