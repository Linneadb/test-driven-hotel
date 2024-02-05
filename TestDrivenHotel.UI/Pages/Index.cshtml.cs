using Microsoft.AspNetCore.Mvc.RazorPages;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.UI.Pages
{
    public class IndexModel : PageModel
    {

        public List<DAL.Models.RoomModel>? AvailableRooms { get; set; }



        public void OnGet()
        {

        }

        public void OnPost()
        {
            BookingLogic bookingLogic = new();

            string featureInput = "Balcony";
            int guestInput = 2;
            DateTime arrivalDateInput = new DateTime(24, 12, 13);
            DateTime departureDateInput = new DateTime(24, 12, 17);

            List<DAL.Models.BookingModel> bookings = DAL.Bookings.GetBookingList();
            List<DAL.Models.RoomModel> rooms = DAL.Rooms.GetRoomList();

            try
            {
                AvailableRooms = bookingLogic.GetAvailableRooms(rooms, bookings, featureInput, guestInput, arrivalDateInput, departureDateInput);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            };
        }
    }
}
