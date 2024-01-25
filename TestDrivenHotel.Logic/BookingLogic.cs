namespace TestDrivenHotel.Logic
{
    public class BookingLogic
    {

        public bool CheckRoomAvailability()
        {
            return true;
        }
        public static bool IsBetweenTwoDates(DateTime dt, DateTime start, DateTime end)
        {
            return dt >= start && dt < end;
        }
    }
}
