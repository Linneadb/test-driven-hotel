using FluentAssertions;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.Tests
{
    public class FilterRoomsTests
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
        public void FilterRooms_ShouldReturnRoomsWithASeaview()
        {
            //Given
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterRooms(testRooms, "Seaview", 1);
            var expectedRooms = testRooms.Where(f => f.Seaview == true).ToList();

            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void FilterRooms_ShouldReturnRoomsWithABalcony()
        {
            //Given
            List<DAL.Models.RoomModel> roomsToSelectFrom = DAL.Rooms.GetRoomList();
            BookingLogic bookingLogic = new();

            //When
            var expectedRooms = roomsToSelectFrom.Where(f => f.Balcony == true).ToList();
            var actualRooms = bookingLogic.FilterRooms(roomsToSelectFrom, "Balcony", 1);

            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void FilterRooms_NoRoomsWithSeaview_ShouldReturnEmptyList()
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
            var actualRooms = bookingLogic.FilterRooms(roomsWithNoSeaview, "Seaview", 1);

            //Then
            actualRooms.Should().BeEquivalentTo(roomsWithNoSeaview);
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
        }

        [Fact]
        public void FilterRooms_NoRoomsWithBalcony_ShouldReturnEmptyList()
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
            var actualRooms = bookingLogic.FilterRooms(roomsWithNoBalcony, "Balcony", 1);

            //Then
            actualRooms.Should().BeEquivalentTo(roomsWithNoBalcony);
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<DAL.Models.RoomModel>>();
        }

        [Fact]
        public void FilterRooms_EmptyList_ShouldThrowArgumentException()
        {
            //Given
            List<DAL.Models.RoomModel> emptyRoomsList = new();
            BookingLogic bookingLogic = new();

            //When
            Action emptyListTest = () => bookingLogic.FilterRooms(emptyRoomsList, "Balcony", 1);

            //Then
            emptyListTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void FilterRooms_nullList_ShouldThrowArgumentException()
        {
            //Given
            List<DAL.Models.RoomModel>? nullRoomsList = null;
            BookingLogic bookingLogic = new();

            //When
            Action nullListTest = () => bookingLogic.FilterRooms(nullRoomsList, "Balcony", 1);

            //Then
            nullListTest.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void FilterRooms_NullProperty_ShouldThrowNullReferenceException()
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
            Action nullPropTest = () => bookingLogic.FilterRooms(roomsWithNullValue, "Balcony", 1);

            //Then
            nullPropTest.Should().Throw<NullReferenceException>();
        }

    }
}
