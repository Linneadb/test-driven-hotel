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
        public void CalculatePrice_ThreeGuests_ShouldReturnTotalPrice1125()
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
            int guests = 3;

            //When
            var actualPrice = bookingLogic.CalculatePrice(room, guests);
            var expectedPrice = room.Price * guests * 0.75;

            //Then
            actualPrice.Should().Be(expectedPrice);
            actualPrice.Should().BePositive();
        }

        //[Fact]
        //Room has no price
        //[Fact]
        //Number of guests is insane (higher than 7)

        /* public double CalculatePrice(RoomModel room, int guests)
         {
             double totalPrice = room.Price;
             //price logic
             if (guests > 1)
                 totalPrice = (double)(room.Price * guests) * 0.75;

             return totalPrice;
         }
        */

    }
}
