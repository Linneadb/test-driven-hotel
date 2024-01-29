using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestDrivenHotel.UI.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            List<DAL.Models.RoomModel> rooms = DAL.Rooms.GetRoomList();
            List<DAL.Models.BookingModel> bookings = DAL.Bookings.GetBookingList();

        }
    }
}
