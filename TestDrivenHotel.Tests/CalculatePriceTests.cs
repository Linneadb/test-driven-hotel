using FluentAssertions;
using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.Tests
{
    public class CalculatePriceTests
    {
        // **** CREATE BOOKING TESTS ****

        BookingLogic bookingLogic = new();

        [Fact]
        public void CalculatePrice_NullRoom_ShouldThrowArgumentNullException()
        {
            //Given
            RoomModel? nullRoom = null;
            int guests = 2;

            //When
            Action nullRoomTest = () => bookingLogic.CalculatePrice(nullRoom, guests);

            //Then
            nullRoomTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CalculatePrice_NullGuests_ShouldThrowArgumentNullException()
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

            int nullGuests = 0;

            //When
            Action nullRoomTest = () => bookingLogic.CalculatePrice(room, nullGuests);

            //Then
            nullRoomTest.Should().Throw<ArgumentNullException>();
        }
        [Fact]
        public void CalculatePrice_NullRoomNullGuests_ShouldThrowArgumentNullException()
        {
            //Given
            RoomModel? nullRoom = null;
            int guests = 0;

            //When
            Action nullRoomTest = () => bookingLogic.CalculatePrice(nullRoom, guests);

            //Then
            nullRoomTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CalculatePrice_TwoGuests_ShouldReturnTotalPrice750()
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
            int guests = 2;

            //When
            var actualPrice = bookingLogic.CalculatePrice(room, guests);
            var expectedPrice = room.Price * guests * 0.75;

            //Then
            actualPrice.Should().Be(expectedPrice);
            actualPrice.Should().Be(750);
            actualPrice.Should().BePositive();
        }
        [Fact]
        public void CalculatePrice_OneGuest_ShouldReturnTotalPrice500()
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
            int guests = 1;

            //When
            var actualPrice = bookingLogic.CalculatePrice(room, guests);
            var expectedPrice = room.Price;

            //Then
            actualPrice.Should().Be(expectedPrice);
            actualPrice.Should().Be(500);
            actualPrice.Should().BePositive();
        }

        [Fact]
        public void CalculatePrice_MoreThanMaxNrOfGuest_ShouldThrowArgumentException()
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
            int toManyGuests = 3;

            //Then
            Action nullRoomTest = () => bookingLogic.CalculatePrice(room, toManyGuests);

            //Then
            nullRoomTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CalculatePrice_MoreThanSevenGuests_ShouldThrowArgumentException()
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
            int toManyGuests = 376;

            //When
            Action nullRoomTest = () => bookingLogic.CalculatePrice(room, toManyGuests);

            //Then
            nullRoomTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CalculatePrice_NullPriceRoom_ShouldThrowArgumentNullException()
        {
            //Given
            RoomModel nullPriceRoom = new()
            {
                Id = 1,
                Description = "Luxury Suite with Ocean View",
                Price = 0,
                MaxNumberOfGuests = 2,
                Seaview = true,
                Balcony = true
            };
            int guests = 2;

            //When
            Action nullRoomTest = () => bookingLogic.CalculatePrice(nullPriceRoom, guests);

            //Then
            nullRoomTest.Should().Throw<ArgumentNullException>();
        }
    }
}
