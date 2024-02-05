using FluentAssertions;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.Tests
{
    public class GetAvailableRoomsTests
    {

        //Test list of RoomModel

        List<DAL.Models.RoomModel> testRooms = new List<DAL.Models.RoomModel>
        {
            new DAL.Models.RoomModel
            {
                Id = 1,
                Description = "Luxury Suite with Ocean View",
                Price = 500,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = true
            },
            new DAL.Models.RoomModel
            {
                Id = 2,
                Description = "Standard Room with City View",
                Price = 200,
                MaxNumberOfGuests = 2,
                Seaview = false,
                Balcony = false
            },
            new DAL.Models.RoomModel
            {
                Id = 3,
                Description = "Family Room with Garden View",
                Price = 350,
                MaxNumberOfGuests = 4,
                Seaview = false,
                Balcony = true
            },
        };

        // **** FILTER FEATURES TESTS *****

        [Fact]
        public void FilterFeatures_Seaview_ShouldReturnOneRoomsWithASeaview()
        {
            //Given
            string feature = "Seaview";
            List<DAL.Models.RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(rooms, feature);
            var expectedRooms = rooms.Where(f => f.Seaview == true).ToList();

            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
            actualRooms.Should().HaveCount(1);
        }

        [Fact]
        public void FilterFeatures_Balcony_ShouldReturnTwoRoomsWithABalcony()
        {
            //Given
            string feature = "Balcony";
            List<DAL.Models.RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(rooms, feature);
            var expectedRooms = rooms.Where(f => f.Balcony == true).ToList();


            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
            actualRooms.Should().HaveCount(2);
        }

        [Fact]
        public void FilterFeatures_None_ShouldReturnAllTestRooms()
        {
            //Given
            string feature = "None";
            List<DAL.Models.RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(rooms, feature);
            var expectedRooms = rooms;


            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
            actualRooms.Should().HaveCount(3);
        }

        [Fact]
        public void FilterFeatures_NoRoomsWithSeaview_ShouldReturnEmptyList()
        {
            //Given
            List<DAL.Models.RoomModel> roomsWithNoSeaview = new List<DAL.Models.RoomModel>()
            {
                new DAL.Models.RoomModel
                {
                Id = 2,
                Description = "Standard Room with City View",
                Price = 200,
                MaxNumberOfGuests = 2,
                Seaview = false,
                Balcony = false
                },
                new DAL.Models.RoomModel
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
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
        }

        [Fact]
        public void FilterFeatures_NoRoomsWithBalcony_ShouldReturnEmptyList()
        {
            //Given
            List<DAL.Models.RoomModel> roomsWithNoBalcony = new List<DAL.Models.RoomModel>()
            {
                new DAL.Models.RoomModel
                {
                Id = 2,
                Description = "Standard Room with City View",
                Price = 200,
                MaxNumberOfGuests = 2,
                Seaview = false,
                Balcony = false
                },
                new DAL.Models.RoomModel
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
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
        }

        [Fact]
        public void FilterFeatures_EmptyList_ShouldReturnEmptyList()
        {
            //Given
            List<DAL.Models.RoomModel> emptyRoomsList = new();
            string feature = "Balcony";
            BookingLogic bookingLogic = new();

            //When
            var emptyList = bookingLogic.FilterFeatures(emptyRoomsList, feature);

            //Then
            emptyList.Should().BeEmpty();
            emptyList.Should().BeOfType<List<DAL.Models.RoomModel>>();
            emptyList.Should().NotBeNull();
        }

        [Fact]
        public void FilterFeatures_nullList_ShouldThrowArgumentNullException()
        {
            //Given
            List<DAL.Models.RoomModel>? nullRoomsList = null;
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
            List<DAL.Models.RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(rooms, feature);

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
        }

        [Fact]
        public void FilterFeatures_NullFeature_ShouldThrowArgumnentNullException()
        {
            //Given
            string? nullFeature = null;
            List<DAL.Models.RoomModel> rooms = testRooms;
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
            List<DAL.Models.RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            Action nullFeatureTest = () => bookingLogic.FilterFeatures(rooms, emptyFeature);

            //Then
            nullFeatureTest.Should().Throw<ArgumentNullException>();
        }

        // **** FILTER GUESTS TESTS *****

        [Fact]
        public void FilterGuests_EmptyList_ShouldReturnEmptyList()
        {
            //Given
            List<DAL.Models.RoomModel> emptyRoomsList = new();
            int guests = 2;
            BookingLogic bookingLogic = new();

            //When
            var emptyList = bookingLogic.FilterGuests(emptyRoomsList, guests);

            //Then
            emptyList.Should().BeEmpty();
            emptyList.Should().BeOfType<List<DAL.Models.RoomModel>>();
            emptyList.Should().NotBeNull();
        }

        [Fact]
        public void FilterGuests_nullList_ShouldThrowArgumentNullException()
        {
            //Given
            List<DAL.Models.RoomModel>? nullRoomsList = null;
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
            List<DAL.Models.RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterGuests(rooms, guests);
            var expectedRooms = rooms.Where(r => r.MaxNumberOfGuests >= guests).ToList();

            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
            actualRooms.Should().HaveCount(1);
        }

        [Fact]
        public void FilterGuests_LargeNumber_ShouldReturnEmptyList()
        {
            //Given
            int guests = 798637904;
            List<DAL.Models.RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterGuests(rooms, guests);

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
        }

        [Fact]
        public void FilterGuests_NullGuests_ShouldThrowArgumnentNullException()
        {
            //Given
            int nullGuests = 0;
            List<DAL.Models.RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            Action nullFeatureTest = () => bookingLogic.FilterGuests(rooms, nullGuests);

            //Then
            nullFeatureTest.Should().Throw<ArgumentNullException>();
        }

        // **** FILTER DATES TESTS ****

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
