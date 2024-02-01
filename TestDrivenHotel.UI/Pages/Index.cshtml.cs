using Microsoft.AspNetCore.Mvc.RazorPages;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.UI.Pages
{
    public class IndexModel : PageModel
    {

        public List<DAL.Models.RoomModel>? FilteredRooms { get; set; }



        public void OnGet()
        {
            List<DAL.Models.BookingModel> bookings = DAL.Bookings.GetBookingList();

        }

        public void OnPost()
        {
            BookingLogic bookingLogic = new();
            string input1 = "Balcony";
            //FilteredRooms = bookingLogic.FilterRooms(input1);
            bookingLogic.FilterRooms(FilteredRooms, input1, 1);
        }
    }
}
