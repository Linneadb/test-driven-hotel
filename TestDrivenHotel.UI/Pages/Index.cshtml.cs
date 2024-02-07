using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.DAL.Repository;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.UI.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public List<RoomModel>? AvailableRooms { get; set; } //Denna ska vidare till nasta webbsida i OnGet:en!

        [Required]
        public string? Feature { get; set; }
        [Required]
        public int Guests { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime DepartureDate { get; set; } = DateTime.Now.AddDays(1);

        public string Message { get; set; }
        public string MessageToGet { get; set; }

        public void OnGet()
        {
            MessageToGet = Message;
        }

        public ActionResult OnPost()
        {

            BookingLogic bookingLogic = new();

            List<BookingModel>? bookings = ListRepository.GetAllBookings();
            List<RoomModel>? rooms = ListRepository.GetAllRooms();

            try
            {
                AvailableRooms = bookingLogic.GetAvailableRooms(rooms, bookings, Feature, Guests, ArrivalDate, DepartureDate);
            }
            catch (ArgumentException ex)
            {
                Message = ex.Message;
                return Page();
            };


            if (AvailableRooms.Count >= 1)
            {
                return RedirectToPage("/AvailableRooms", new { Feature, Guests, ArrivalDate, DepartureDate });
            }
            else
            {
                Message = "There are no available rooms for your criteria";
                return Page();
            }


        }
    }
}
