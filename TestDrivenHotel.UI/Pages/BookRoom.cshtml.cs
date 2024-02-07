using Microsoft.AspNetCore.Mvc.RazorPages;
using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.DAL.Repository;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.UI.Pages
{
    public class BookRoomModel : PageModel
    {
        public int RoomId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }

        public string? Message { get; set; }

        public RoomModel? RoomToBook { get; set; }

        public BookingModel? NewBooking { get; set; }

        public string? DateOnly { get; set; }

        public void OnGet(int roomId, DateTime arrivalDate, DateTime departureDate)
        {
            this.RoomId = roomId;
            this.ArrivalDate = arrivalDate;
            this.DepartureDate = departureDate;

            List<RoomModel>? rooms = ListRepository.GetAllRooms();
            RoomToBook = rooms.FirstOrDefault(r => r.Id == roomId);

            if (RoomToBook != null)
            {
                BookingLogic bookingLogic = new();
                NewBooking = bookingLogic.CreateBooking(RoomToBook, arrivalDate, departureDate);
                DateOnly = NewBooking.StartDate.Value.Date.ToShortDateString();
            }

            Message = "Congratulations! Your booking was successfull!";
        }
    }
}
