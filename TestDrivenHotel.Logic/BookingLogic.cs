using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.DAL.Repository;

namespace TestDrivenHotel.Logic
{
    public class BookingLogic
    {
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

        public double CalculatePrice(RoomModel room, int guests)
        {
            if (guests <= 0 || room == null || room.Price <= 0)
                throw new ArgumentNullException();
            if (guests > 7 || guests > room.MaxNumberOfGuests)
                throw new ArgumentException();

            double totalPrice = room.Price;

            //price logic
            if (guests == 1)
            {
                return totalPrice;
            }
            else return totalPrice *= guests * 0.75;
        }

        public BookingModel CreateBooking(RoomModel room, DateTime arrivalDate, DateTime departureDate, String comment = "")
        {
            if (room == null || room.Id < 1)
                throw new ArgumentNullException();

            if (arrivalDate > departureDate || arrivalDate < DateTime.Today)
                throw new ArgumentException("Dates are incorrect");

            //getting the highest Id from bookingList
            var bookings = ListRepository.GetAllBookings();
            int bookingId = (bookings.Max(b => b.Id)) + 1;

            BookingModel newBooking = new BookingModel
            {
                Id = bookingId,
                RoomId = room.Id,
                StartDate = arrivalDate,
                EndDate = departureDate,
                Created = DateTime.Now,
                Comment = comment
            };

            //adding booking to bookingList
            ListRepository.AddBooking(newBooking);

            return newBooking;
        }
    }
}


