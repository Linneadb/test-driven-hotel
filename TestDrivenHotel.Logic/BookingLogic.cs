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

        public List<RoomModel>? FilterRooms(List<RoomModel> rooms, string feature)
        {

            //guard clauses
            if (rooms == null || rooms.Count < 1)
                throw new ArgumentException("No rooms available to filter");

            if (String.IsNullOrEmpty(feature))
                throw new ArgumentException("No feature to filter rooms were given");

            switch (feature)
            {
                case "Seaview":
                    return rooms.Where(f => f.Seaview).ToList();
                case "Balcony":
                    return rooms.Where(f => f.Balcony).ToList();
                default:
                    return null;
            }
        }
    }

    /*if (rooms.Any(room => room.GetType()
                          .GetProperties()
                          .Select(pi => pi.GetValue(room))
                          .Any(value => value == null)))
                throw new NullReferenceException();
    */
}
