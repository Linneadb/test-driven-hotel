using Microsoft.AspNetCore.Mvc.RazorPages;
using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.UI.Pages
{
    public class BookRoomModel : PageModel
    {
        public int RoomId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }

        public string Message { get; set; }
        public void OnGet(int roomId, DateTime arrivalDate, DateTime departureDate)
        {
            this.RoomId = roomId;
            this.ArrivalDate = arrivalDate;
            this.DepartureDate = departureDate;

            List<RoomModel> rooms = DAL.Rooms.GetRoomList();
            RoomModel? roomToBook = rooms.FirstOrDefault(r => r.Id == roomId);

            BookingLogic bookingLogic = new();
            BookingModel newBooking = bookingLogic.CreateBooking(roomToBook, arrivalDate, departureDate);
        }
    }
}
