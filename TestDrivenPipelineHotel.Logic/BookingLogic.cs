using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Logic
{
    public class BookingLogic
    {
        public List<BookingModel> SearchRoom(DateTime dateFrom, DateTime dateTo, string roomType)
        {
            throw new NotImplementedException();
        }

        public BookingModel SetCheckInDate(DateTime date, BookingModel booking)
        {
            booking.DateFrom = date;
            return booking;
        }
    }
}
