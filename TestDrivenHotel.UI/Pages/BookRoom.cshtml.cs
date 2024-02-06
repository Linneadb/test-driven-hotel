using Microsoft.AspNetCore.Mvc.RazorPages;
using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.UI.Pages
{
    public class BookRoomModel : PageModel
    {
        public int RoomId { get; set; }
        public double Price { get; set; }

        public string Message { get; set; }
        public void OnGet(int roomId, int guests)
        {
            RoomId = roomId;
            List<RoomModel> rooms = DAL.Rooms.GetRoomList();
            RoomModel? roomToBook = rooms.FirstOrDefault(r => r.Id == roomId);

            BookingLogic bookingLogic = new();
            Price = bookingLogic.CalculatePrice(roomToBook, 2);
        }

        //public ActionResult OnPost()
        //{ 

        //booked Room = CreateBooking(roomToBook, )

        //}
    }
}
