using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.DAL.Repository;

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

        public BookingModel CreateBooking(RoomModel room, DateTime arrivalDate, DateTime departureDate, String comment = "")
        {
            BookingModel newBooking = new BookingModel
            {
                Id = 10,
                RoomId = room.Id,
                StartDate = arrivalDate,
                EndDate = departureDate,
                Created = DateTime.Now,
                Comment = comment
            };

            ListRepository.AddBooking(newBooking);

            return newBooking;
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
                throw new ArgumentNullException("There is no booking list to compare dates to");

            if (endDate < startDate)
                throw new ArgumentException("Departure date must be later than arrival date");

            if (startDate < DateTime.Today)
                throw new ArgumentException("Arrival date must be in the future");

            List<BookingModel> overlappingBookings = bookings
                .Where(b => startDate < b.EndDate && endDate > b.StartDate)
                .ToList();

            List<int> overlappingRoomIds = overlappingBookings.Select(b => b.RoomId).ToList();

            return rooms
                    .Where(r => !overlappingRoomIds.Contains(r.Id))
                    .ToList();
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


