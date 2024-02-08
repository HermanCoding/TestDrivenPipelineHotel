using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Logic
{
    public class BookingLogic
    {
        public BookingModel SetCheckInDate(DateTime date, BookingModel booking)
        {
            booking.DateFrom = date;
            return booking;
        }
    }
}
