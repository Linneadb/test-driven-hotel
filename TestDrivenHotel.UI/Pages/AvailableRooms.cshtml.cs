using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestDrivenHotel.UI.Pages
{
    public class AvailableRoomsModel : PageModel
    {
        public int RoomId { get; set; }

        public int Guests { get; set; }
        public void OnGet()
        {
            //Available Rooms logik ska kora har ocksa
        }

        public ActionResult OnPost()
        {

            //AvailableRooms.Count >= 1 &&
            //if available romms >=1 => till nasta sida, annars vissa meddelande
            if (ModelState.IsValid)
            {
                return RedirectToPage("/BookRoom", new { RoomId, Guests });     // SKicka data till bookingsidan
            }
            else
            {

                return Page();
            }

        }
    }
}
