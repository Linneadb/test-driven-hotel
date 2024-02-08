using FluentAssertions;
using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.Tests
{
    public class CreateBookingTests
    {
        // **** CREATE BOOKING TESTS ****

        BookingLogic bookingLogic = new();

        [Fact]
        public void CreateBooking_NoRoomId_ShouldThrowArgumentNullException()
        {
            //Given
            RoomModel noIdRoom = new()
            {
                Id = 0,
                Description = "Luxury Suite with Ocean View",
                Price = 500,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = true
            };

            DateTime arrival = new(2024, 12, 13);
            DateTime departure = new(2024, 12, 17);

            //When
            Action nullRoomTest = () => bookingLogic.CreateBooking(noIdRoom, arrival, departure);

            //Then
            nullRoomTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateBooking_nullRoom_ShouldThrowArgumentNullException()
        {
            //Given
            RoomModel? nullRoom = null;
            DateTime arrival = new(2024, 12, 13);
            DateTime departure = new(2024, 12, 17);

            //When
            Action nullListTest = () => bookingLogic.CreateBooking(nullRoom, arrival, departure);

            //Then
            nullListTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateBooking_HasComment_ShouldReturnABooking()
        {
            //Given
            RoomModel room = new()
            {
                Id = 1,
                Description = "Luxury Suite with Ocean View",
                Price = 500,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = true
            };

            string comment = "Will arrive late";
            DateTime arrival = new(2024, 3, 5);
            DateTime departure = new(2024, 3, 10);

            //When
            var actualBooking = bookingLogic.CreateBooking(room, arrival, departure, comment);

            //Then
            actualBooking.Should().NotBeNull();
            actualBooking.Should().BeOfType<BookingModel>();
        }

        [Fact]
        public void CreateBooking_DepartureBeforeArrival_ShouldThrowArgumentException()
        {
            //Given
            RoomModel room = new()
            {
                Id = 1,
                Description = "Luxury Suite with Ocean View",
                Price = 500,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = true
            };
            DateTime arrival = new(2024, 12, 17);
            DateTime departure = new(2024, 12, 13);

            //When
            Action datesTest = () => bookingLogic.CreateBooking(room, arrival, departure);

            //Then
            datesTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateBooking_BookingInThePast_ShouldThrowArgumentException()
        {
            //Given
            RoomModel room = new()
            {
                Id = 1,
                Description = "Luxury Suite with Ocean View",
                Price = 500,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = true
            };
            DateTime arrival = new(2023, 2, 13);
            DateTime departure = new(2023, 2, 17);

            //When
            Action datesTest = () => bookingLogic.CreateBooking(room, arrival, departure);

            //Then
            datesTest.Should().Throw<ArgumentException>();
        }
    }
}
