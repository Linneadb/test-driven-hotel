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

        /* public List<RoomModel>? FilterRooms(List<RoomModel> rooms, string feature)
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
        */


        public List<RoomModel> FilterRooms(List<DAL.Models.RoomModel> rooms, string feature, int guests)
        {
            // Guard clauses
            if (rooms == null || rooms.Count < 1)
                throw new ArgumentException("No rooms available to filter");

            if (CheckForNullProperties(rooms))
                throw new NullReferenceException("There are rooms that contain null values");

            List<DAL.Models.RoomModel>? roomsFilteredByFeatures = FilterFeatures(rooms, feature);
            List<DAL.Models.RoomModel>? roomsFilteredByNrOfGuests = FilterGuests(roomsFilteredByFeatures, guests);

            return roomsFilteredByNrOfGuests;
        }

        private List<RoomModel>? FilterGuests(List<DAL.Models.RoomModel> rooms, int guests)
        {
            if (guests > 0)
            {
                return rooms.Where(r => r.MaxNumberOfGuests >= guests).ToList();
            }

            throw new ArgumentNullException("There is no number of guests sumbitted");
        }

        private List<DAL.Models.RoomModel>? FilterFeatures(List<DAL.Models.RoomModel> rooms, string feature)
        {
            if (String.IsNullOrEmpty(feature))
            {
                // Switch statement to filter rooms based on the feature
                switch (feature)
                {
                    case "Seaview":
                        return rooms.Where(r => r.Seaview).ToList();
                    case "Balcony":
                        return rooms.Where(r => r.Balcony).ToList();
                    default:
                        return rooms.Where(r => !r.Balcony && !r.Seaview).ToList();
                }
            }
            throw new ArgumentNullException("There is not feature given");
        }

        private bool CheckForNullProperties(List<RoomModel> rooms)
        {
            return rooms.Any(room => room.GetType()
                              .GetProperties()
                              .Select(pi => pi.GetValue(room))
                              .Any(value => value == null));
        }
    }
}

