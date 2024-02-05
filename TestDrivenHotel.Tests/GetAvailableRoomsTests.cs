using FluentAssertions;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.Tests
{
    public class GetAvailableRoomsTests
    {
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


        [Fact]
        public void FilterFeatures_ShouldReturnRoomsWithASeaview()
        {
            //Given
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(testRooms, "Seaview");
            var expectedRooms = testRooms.Where(f => f.Seaview == true).ToList();

            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void FilterFeatures_ShouldReturnRoomsWithABalcony()
        {
            //Given
            List<DAL.Models.RoomModel> roomsToSelectFrom = DAL.Rooms.GetRoomList();
            BookingLogic bookingLogic = new();

            //When
            var expectedRooms = roomsToSelectFrom.Where(f => f.Balcony == true).ToList();
            var actualRooms = bookingLogic.FilterFeatures(roomsToSelectFrom, "Balcony");

            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
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
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(roomsWithNoSeaview, "Seaview");

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
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(roomsWithNoBalcony, "Balcony");

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
        }

        [Fact]
        public void FilterFeatures_EmptyList_ShouldReturnEmptyList()
        {
            //Given
            List<DAL.Models.RoomModel> emptyRoomsList = new();
            BookingLogic bookingLogic = new();

            //When
            var emptyList = bookingLogic.FilterFeatures(emptyRoomsList, "Balcony");

            //Then
            emptyList.Should().BeEmpty();
            emptyList.Should().BeOfType<List<DAL.Models.RoomModel>>();
            emptyList.Should().NotBeNull();
        }

        [Fact]
        public void FilterFeatures_nullList_ShouldThrowNullArgumentException()
        {
            //Given
            List<DAL.Models.RoomModel>? nullRoomsList = null;
            BookingLogic bookingLogic = new();

            //When
            Action nullListTest = () => bookingLogic.FilterFeatures(nullRoomsList, "Balcony");

            //Then
            nullListTest.Should().Throw<ArgumentNullException>();
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
        */
    }
}
