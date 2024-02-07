using TestDrivenHotel.DAL.Models;

namespace TestDrivenHotel.DAL.Repository
{
    internal interface IRepository
    {
        public static abstract List<RoomModel>? GetAllRooms();
        //public RoomModel? GetRoomById(int Id);

        public static abstract List<BookingModel> GetAllBookings();
        public static abstract void AddBooking(BookingModel booking);

    }
}
