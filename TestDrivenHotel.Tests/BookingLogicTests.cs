using FluentAssertions;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.Tests
{
    public class BookingLogicTests
    {
        [Fact]
        public void SelectRoomFeatures_ShouldReturnRoomsWithASeaview()
        {
            //Given
            List<DAL.Models.RoomModel> roomsToSelectFrom = DAL.Rooms.GetRoomList();

            //When
            var expectedRooms = BookingLogic.FilterRooms(roomsToSelectFrom, "Seaview");

            //Then
            var actualRooms = roomsToSelectFrom.Where(f => f.Seaview == true).ToList();

            actualRooms.Should().BeEquivalentTo(expectedRooms);
        }

        [Fact]
        public void SelectRoomFeatures_ShouldReturnRoomsWithABalcony()
        {
            //Given
            List<DAL.Models.RoomModel> roomsToSelectFrom = DAL.Rooms.GetRoomList();

            //When
            var expectedRooms = BookingLogic.FilterRooms(roomsToSelectFrom, "Balcony");

            //Then
            var actualRooms = roomsToSelectFrom.Where(f => f.Balcony == true).ToList();

            actualRooms.Should().BeEquivalentTo(expectedRooms);
        }

        [Fact]
        public void SelectRoomFeatures_NoRoomsWithSeaview_ShouldReturnEmptyList()
        {
            //Given
            List<DAL.Models.RoomModel> roomsWithNoSeaview = new List<DAL.Models.RoomModel>()
            {
                new DAL.Models.RoomModel {
                Id = 2,
                Description = "Standard Room with City View",
                Price = 200,
                MaxNumberOfGuests = 2,
                Seaview = false,
                Balcony = false
            },
        };



            //When
            var expectedRooms = BookingLogic.FilterRooms(roomsWithNoSeaview, "Seaview");

            //Then
            var actualRooms = roomsWithNoSeaview.Where(f => f.Seaview == true).ToList();

            actualRooms.Should().BeEquivalentTo(expectedRooms);
        }


        //Test for null or empty
        //Test that it is a List in input and output. 
        [Fact]
        public void SelectRoomFeatures_EmptyList_ShouldReturnEmptyListException()
        {
            //Given
            List<DAL.Models.RoomModel> rooms = [];

            //When
            var expectedRooms = BookingLogic.FilterRooms(rooms, "Balcony");

            //Then
            expectedRooms.Should().BeEmpty();
        }
    }
}