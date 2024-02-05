using TestDrivenHotel.DAL.Models;

namespace TestDrivenHotel.Logic
{
    public class BookingLogic
    {

        //Choose a room and see the room description
        public bool SelectRoom()
        {

            throw new NotImplementedException();

            //return GetRoomById;
        }

        public double CalculatePrice(RoomModel room, int guests)
        {
            double totalPrice = room.Price;
            //price logic
            if (guests > 1)
                totalPrice = (double)(room.Price * guests) * 0.75;

            return totalPrice;
        }

        public BookingModel CreateBooking()
        {
            throw new NotImplementedException();
            //Should add booking to BookingList
        }


        public List<RoomModel> GetAvailableRooms(List<RoomModel> rooms, List<BookingModel> bookings, string feature, int guests, DateTime arrivalDate, DateTime departureDate)
        {
            if (rooms == null)
                throw new ArgumentNullException();

            List<RoomModel>? roomsFilteredByFeatures = FilterFeatures(rooms, feature);
            List<RoomModel>? roomsFilteredByNrOfGuests = FilterGuests(roomsFilteredByFeatures, guests);
            List<RoomModel>? availableRooms = FilterDates(roomsFilteredByNrOfGuests, bookings, arrivalDate, departureDate);

            return availableRooms;
        }


        //Broken out functions from GetAvailableRooms()

        public List<RoomModel>? FilterFeatures(List<RoomModel> rooms, string feature)
        {
            if (String.IsNullOrEmpty(feature))
                throw new ArgumentNullException("There is no feature given");

            switch (feature)
            {
                case "Seaview":
                    return rooms.Where(r => r.Seaview).ToList();
                case "Balcony":
                    return rooms.Where(r => r.Balcony).ToList();
                case "None":
                    return rooms;
                default:
                    return new List<RoomModel>();
            }
        }

        public List<RoomModel>? FilterGuests(List<RoomModel> rooms, int guests)
        {
            if (guests <= 0)
                throw new ArgumentNullException("There is no number of guests sumbitted");

            return rooms.Where(r => r.MaxNumberOfGuests >= guests).ToList();

        }

        public List<RoomModel>? FilterDates(List<RoomModel> rooms, List<BookingModel> bookings, DateTime startDate, DateTime endDate)
        {
            if (bookings == null || bookings.Count < 1)
                throw new ArgumentNullException("There is no bookingList to compare dates to");

            /* List<BookingModel> availableBookings = bookings
                 .Where(b => b.EndDate <= arrivalDate && b.StartDate >= arrivalDate && b.EndDate <= departureDate && b.StartDate >= arrivalDate)
                 .ToList();

             List<int> availableRoomIds = availableBookings.Select(b => b.RoomId).ToList();

             return rooms.Where(r => availableRoomIds.Contains(r.Id)).ToList();


             */

            List<BookingModel> overlappingBookings = bookings
                // .Where(b => !(b.EndDate >= arrivalDate && b.StartDate <= departureDate))
                .Where(b => !(b.StartDate >= endDate || startDate >= b.EndDate)) //(b.StartDate <= startDate) && (endDate <= b.EndDate)) ||
                .ToList();

            List<int> overlappingRoomIds = overlappingBookings.Select(b => b.RoomId).ToList();

            List<RoomModel> availableRooms = rooms
                    .Where(r => !overlappingRoomIds.Contains(r.Id))
                    .ToList();

            return availableRooms;

        }
        /*
        public bool IsBooked(List<BookingModel> bookings, DateTime start, DateTime end)
        {

            foreach (BookingModel b in bookings)
            {
                if (b.StartDate <= start && start <= b.EndDate) 
                    

            }

        }
            
            // if ((arrivalDate <= EndDate) && (StartDate <= departureDate))
            //   overlaps = true;
        


    }


    /*
  public static bool IsBetweenTwoDates(DateTime dt, DateTime start, DateTime end)
  {
      return dt >= start && dt < end;
  }


      if (CheckForNullProperties(rooms))
          throw new NullReferenceException("There are rooms that contain null values");

  private bool CheckForNullProperties(List<RoomModel> rooms)
  {
      return rooms.Any(room => room.GetType()
                        .GetProperties()
                        .Select(pi => pi.GetValue(room))
                        .Any(value => value == null));
  }

  */
    }
}


