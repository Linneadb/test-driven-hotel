using FluentAssertions;
using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.Tests
{
    public class GetAvailableRoomsTests
    {

        //Test list of RoomModel

        List<RoomModel> testRooms = new List<RoomModel>
        {
            new RoomModel
            {
                Id = 1,
                Description = "Luxury Suite with Ocean View",
                Price = 500,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = true
            },
            new RoomModel
            {
                Id = 2,
                Description = "Standard Room with City View",
                Price = 200,
                MaxNumberOfGuests = 2,
                Seaview = false,
                Balcony = false
            },
            new RoomModel
            {
                Id = 3,
                Description = "Family Room with Garden View",
                Price = 350,
                MaxNumberOfGuests = 4,
                Seaview = false,
                Balcony = true
            },
        };

        // Test list of BookingModel

        List<BookingModel> testBookings = new List<BookingModel>
        {
            new BookingModel
            {
                Id = 1,
                RoomId = 1,
                StartDate = new DateTime(2024, 2, 5),
                EndDate = new DateTime(2024, 2, 10),
                Created = DateTime.Now,
                Comment = "Honeymoon getaway"
            },
            new BookingModel
            {
                Id = 2,
                RoomId = 2,
                StartDate = new DateTime(2024, 3, 15),
                EndDate = new DateTime(2024, 3, 20),
                Created = DateTime.Now,
                Comment = "Business conference"
            },
            new BookingModel
            {
                Id = 3,
                RoomId = 3,
                StartDate = new DateTime(2024, 4, 10),
                EndDate = new DateTime(2024, 4, 15),
                Created = DateTime.Now,
                Comment = "Family vacation"
            },
        };


        // **** FILTER FEATURES TESTS *****

        [Fact]
        public void FilterFeatures_Seaview_ShouldReturnOneRoomsWithASeaview()
        {
            //Given
            string feature = "Seaview";
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(rooms, feature);
            var expectedRooms = rooms.Where(f => f.Seaview == true).ToList();

            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
            actualRooms.Should().HaveCount(1);
        }

        [Fact]
        public void FilterFeatures_Balcony_ShouldReturnTwoRoomsWithABalcony()
        {
            //Given
            string feature = "Balcony";
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(rooms, feature);
            var expectedRooms = rooms.Where(f => f.Balcony == true).ToList();


            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
            actualRooms.Should().HaveCount(2);
        }

        [Fact]
        public void FilterFeatures_None_ShouldReturnAllTestRooms()
        {
            //Given
            string feature = "None";
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(rooms, feature);
            var expectedRooms = rooms;


            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
            actualRooms.Should().HaveCount(3);
        }

        [Fact]
        public void FilterFeatures_NoRoomsWithSeaview_ShouldReturnEmptyList()
        {
            //Given
            List<RoomModel> roomsWithNoSeaview = new List<RoomModel>()
            {
                new RoomModel
                {
                Id = 2,
                Description = "Standard Room with City View",
                Price = 200,
                MaxNumberOfGuests = 2,
                Seaview = false,
                Balcony = false
                },
                new RoomModel
                {
                Id = 3,
                Description = "Standard Room with City View",
                Price = 200,
                MaxNumberOfGuests = 2,
                Seaview = false,
                Balcony = true,
                },
            };
            string feature = "Seaview";
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(roomsWithNoSeaview, feature);

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<RoomModel>>();
        }

        [Fact]
        public void FilterFeatures_NoRoomsWithBalcony_ShouldReturnEmptyList()
        {
            //Given
            List<RoomModel> roomsWithNoBalcony = new List<RoomModel>()
            {
                new RoomModel
                {
                Id = 2,
                Description = "Standard Room with City View",
                Price = 200,
                MaxNumberOfGuests = 2,
                Seaview = false,
                Balcony = false
                },
                new RoomModel
                {
                Id = 3,
                Description = "Standard Room with City View",
                Price = 200,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = false,
                },
            };
            string feature = "Balcony";
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(roomsWithNoBalcony, feature);

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<RoomModel>>();
        }

        [Fact]
        public void FilterFeatures_EmptyRoomsList_ShouldReturnEmptyList()
        {
            //Given
            List<RoomModel> emptyRoomsList = new();
            string feature = "Balcony";
            BookingLogic bookingLogic = new();

            //When
            var emptyList = bookingLogic.FilterFeatures(emptyRoomsList, feature);

            //Then
            emptyList.Should().BeEmpty();
            emptyList.Should().BeOfType<List<RoomModel>>();
            emptyList.Should().NotBeNull();
        }

        [Fact]
        public void FilterFeatures_nullRoomsList_ShouldThrowArgumentNullException()
        {
            //Given
            List<RoomModel>? nullRoomsList = null;
            string feature = "Balcony";
            BookingLogic bookingLogic = new();

            //When
            Action nullListTest = () => bookingLogic.FilterFeatures(nullRoomsList, feature);

            //Then
            nullListTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FilterFeatures_InvalidFeature_ShouldReturnEmptyList()
        {
            //Given
            string feature = "Banana";
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(rooms, feature);

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<RoomModel>>();
        }

        [Fact]
        public void FilterFeatures_NullFeature_ShouldThrowArgumnentNullException()
        {
            //Given
            string? nullFeature = null;
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            Action nullFeatureTest = () => bookingLogic.FilterFeatures(rooms, nullFeature);

            //Then
            nullFeatureTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FilterFeatures_EmptyFeature_ShouldThrowArgumnentNullException()
        {
            //Given
            string? emptyFeature = "";
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            Action nullFeatureTest = () => bookingLogic.FilterFeatures(rooms, emptyFeature);

            //Then
            nullFeatureTest.Should().Throw<ArgumentNullException>();
        }

        // **** FILTER GUESTS TESTS *****

        [Fact]
        public void FilterGuests_EmptyRoomsList_ShouldReturnEmptyList()
        {
            //Given
            List<RoomModel> emptyRoomsList = new();
            int guests = 2;
            BookingLogic bookingLogic = new();

            //When
            var emptyList = bookingLogic.FilterGuests(emptyRoomsList, guests);

            //Then
            emptyList.Should().BeEmpty();
            emptyList.Should().BeOfType<List<RoomModel>>();
            emptyList.Should().NotBeNull();
        }

        [Fact]
        public void FilterGuests_nullRoomsList_ShouldThrowArgumentNullException()
        {
            //Given
            List<RoomModel>? nullRoomsList = null;
            int guests = 2;
            BookingLogic bookingLogic = new();

            //When
            Action nullListTest = () => bookingLogic.FilterGuests(nullRoomsList, guests);

            //Then
            nullListTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FilterGuests_NormalNumber_ShouldReturnOneRoom()
        {
            //Given
            int guests = 3;
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterGuests(rooms, guests);
            var expectedRooms = rooms.Where(r => r.MaxNumberOfGuests >= guests).ToList();

            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
            actualRooms.Should().HaveCount(1);
        }

        [Fact]
        public void FilterGuests_LargeNumber_ShouldReturnEmptyList()
        {
            //Given
            int guests = 798637904;
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterGuests(rooms, guests);

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<RoomModel>>();
        }

        [Fact]
        public void FilterGuests_NullGuests_ShouldThrowArgumnentNullException()
        {
            //Given
            int nullGuests = 0;
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            Action nullFeatureTest = () => bookingLogic.FilterGuests(rooms, nullGuests);

            //Then
            nullFeatureTest.Should().Throw<ArgumentNullException>();
        }

        // **** FILTER DATES TESTS ****

        [Fact]
        public void FilterDates_EmptyRoomsList_ShouldReturnEmptyList()
        {
            //Given
            List<RoomModel> emptyRoomsList = new();
            List<BookingModel>? bookings = testBookings;
            DateTime arrival = new DateTime(2024, 12, 13);
            DateTime departure = new DateTime(2024, 12, 17);
            BookingLogic bookingLogic = new();

            //When
            var emptyList = bookingLogic.FilterDates(emptyRoomsList, bookings, arrival, departure);

            //Then
            emptyList.Should().BeEmpty();
            emptyList.Should().NotBeNull();
            emptyList.Should().BeOfType<List<RoomModel>>();
        }

        [Fact]
        public void FilterDates_nullRoomsList_ShouldThrowArgumentNullException()
        {
            //Given
            List<RoomModel>? nullRoomsList = null;
            List<BookingModel>? bookings = testBookings;
            DateTime arrival = new DateTime(2024, 12, 13);
            DateTime departure = new DateTime(2024, 12, 17);
            BookingLogic bookingLogic = new();

            //When
            Action nullListTest = () => bookingLogic.FilterDates(nullRoomsList, bookings, arrival, departure);

            //Then
            nullListTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FilterDates_EmptyBookingsList_ShouldReturnArgumnentNullException()
        {
            //Given
            List<RoomModel> rooms = testRooms;
            List<BookingModel>? EmptyBookingsList = new();
            DateTime arrival = new DateTime(2024, 12, 13);
            DateTime departure = new DateTime(2024, 12, 17);
            BookingLogic bookingLogic = new();

            //When
            Action emptyListTest = () => bookingLogic.FilterDates(rooms, EmptyBookingsList, arrival, departure);

            //Then
            emptyListTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FilterDates_nullBookingsList_ShouldThrowArgumentNullException()
        {
            //Given
            List<RoomModel> rooms = testRooms;
            List<BookingModel>? nullBookingsList = null;
            DateTime arrival = new DateTime(2024, 12, 13);
            DateTime departure = new DateTime(2024, 12, 17);
            BookingLogic bookingLogic = new();

            //When
            Action nullListTest = () => bookingLogic.FilterDates(rooms, nullBookingsList, arrival, departure);

            //Then
            nullListTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FilterDates_AvailableDates_ShouldReturnThreeAvailableRooms()
        {
            //Given
            List<RoomModel> rooms = testRooms;
            List<BookingModel>? bookings = testBookings;
            DateTime arrival = new DateTime(2024, 12, 13);
            DateTime departure = new DateTime(2024, 12, 17);
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterDates(rooms, bookings, arrival, departure);

            //Then
            actualRooms.Should().NotBeEmpty();
            actualRooms.Should().NotBeNull();
            actualRooms.Should().BeOfType<List<RoomModel>>();
            actualRooms.Should().HaveCount(3);
        }

        [Fact]
        public void FilterDates_DatesWithinBookedDates_ShouldReturnTwoAvailableRooms()  //new dates are WITHIN booking range
        {
            //Given
            List<RoomModel> rooms = testRooms;
            List<BookingModel>? bookings = testBookings;
            DateTime arrival = new DateTime(2024, 4, 11);
            DateTime departure = new DateTime(2024, 4, 12);
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterDates(rooms, bookings, arrival, departure);

            //Then
            actualRooms.Should().NotBeEmpty();
            actualRooms.Should().NotBeNull();
            actualRooms.Should().BeOfType<List<RoomModel>>();
            actualRooms.Should().HaveCount(2);
        }

        [Fact]
        public void FilterDates_DatesOverlappingBookedDates_ShouldReturnTwoAvailableRooms()
        {
            //Given
            List<RoomModel> rooms = testRooms;
            List<BookingModel>? bookings = testBookings;
            DateTime arrival = new DateTime(2024, 4, 13);
            DateTime departure = new DateTime(2024, 4, 17);
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterDates(rooms, bookings, arrival, departure);

            //Then
            actualRooms.Should().NotBeEmpty();
            actualRooms.Should().NotBeNull();
            actualRooms.Should().BeOfType<List<RoomModel>>();
            actualRooms.Should().HaveCount(2);
        }

        [Fact]
        public void FilterDates_DatesOverBookedDates_ShouldReturnEmptyList()
        {
            //Given
            List<RoomModel> rooms = testRooms;
            List<BookingModel>? bookings = testBookings;
            DateTime arrival = new DateTime(2024, 2, 4);
            DateTime departure = new DateTime(2024, 4, 16);
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterDates(rooms, bookings, arrival, departure);

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().NotBeNull();
            actualRooms.Should().BeOfType<List<RoomModel>>();
        }





        /*
        [Fact]
        public void FilterFeatures_NullProperty_ShouldThrowNullReferenceException()
        {
            //Given
            List<DAL.Models.RoomModel> roomsWithNullValue = new List<DAL.Models.RoomModel>()
            {
                new DAL.Models.RoomModel {
                Id = 2,
                Description = null,
                Price = 400,
                MaxNumberOfGuests = 2,
                Seaview = false,
                Balcony = false
                },
            };
            BookingLogic bookingLogic = new();

            //When
            Action nullPropTest = () => bookingLogic.FilterFeatures(roomsWithNullValue, "Balcony");

            //Then
            nullPropTest.Should().Throw<NullReferenceException>();
        }

          public List<RoomModel>? FilterGuests(List<RoomModel> rooms, int guests)
        {
            if (guests <= 0)
                throw new ArgumentNullException("There is no number of guests sumbitted");

            return rooms.Where(r => r.MaxNumberOfGuests >= guests).ToList();

        }


         */


    }
}
