namespace TestDrivenHotel.DAL.Models
{
    public class BookingModel
    {
        //Room id
        public int Id { get; set; }
        //Foreign key, not nullable
        public int RoomId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Created { get; set; }
        public string Comment { get; set; } = string.Empty;

        // Navigation property
        public RoomModel? Room { get; set; }
    }
}
