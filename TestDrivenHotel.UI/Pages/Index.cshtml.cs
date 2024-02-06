using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.UI.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {


        public List<DAL.Models.RoomModel>? AvailableRooms { get; set; } //Denna ska vidare till nasta webbsida i OnGet:en!

        [Required]
        public string? Feature { get; set; }
        [Required]
        public int Guest { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }

        public string Message { get; set; }
        public string MessageToGet { get; set; }

        public void OnGet()
        {
            MessageToGet = Message;
        }

        public ActionResult OnPost()
        {

            BookingLogic bookingLogic = new();

            Feature = "Balcony";
            Guest = 2;
            ArrivalDate = new DateTime(24, 12, 13);
            DepartureDate = new DateTime(24, 12, 17);


            List<DAL.Models.BookingModel> bookings = DAL.Bookings.GetBookingList();
            List<DAL.Models.RoomModel> rooms = DAL.Rooms.GetRoomList();

            try
            {
                AvailableRooms = bookingLogic.GetAvailableRooms(rooms, bookings, Feature, Guest, ArrivalDate, DepartureDate);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            };


            //if available romms >=1 => till nasta sida, annars vissa meddelande
            if (AvailableRooms.Count >= 1 && ModelState.IsValid)
            {
                return RedirectToPage("/AvailableRooms", new { Feature, Guest, ArrivalDate, DepartureDate });     // SKicka data till ny sida och gor filtreringen dar igen
            }
            else
            {
                if (Message == null)
                {
                    Message = "There are no available rooms for your criteria";
                }
                return Page();
            }

        }
    }
}
