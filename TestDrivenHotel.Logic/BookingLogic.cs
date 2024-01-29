using TestDrivenHotel.DAL.Models;

namespace TestDrivenHotel.Logic
{
    public class BookingLogic
    {
        public BookingModel CreateBooking()
        {
            throw new NotImplementedException();
        }
        public bool CheckRoomAvailability()
        {
            return true;
        }
        public static bool IsBetweenTwoDates(DateTime dt, DateTime start, DateTime end)
        {
            return dt >= start && dt < end;
        }

        public static List<RoomModel>? FilterRooms(List<RoomModel> rooms, string feature)
        {
            if (feature == "Seaview")
            {
                return rooms.Where(f => f.Seaview == true).ToList();
            }
            if (feature == "Balcony")
            {
                return rooms.Where(f => f.Balcony == true).ToList();
            }
            else return null;
        }
    }
}
