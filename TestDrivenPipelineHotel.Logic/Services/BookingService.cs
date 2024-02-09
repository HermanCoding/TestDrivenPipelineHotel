using TestDrivenPipelineHotel.Data.Models;
using TestDrivenPipelineHotel.Logic.Interfaces;

namespace TestDrivenPipelineHotel.Logic.Services
{
    public class BookingService : IBookingService
    {
        public BookingModel SetCheckInDate(DateTime date, BookingModel booking)
        {
            booking.DateFrom = date;
            return booking;
        }
    }
}
