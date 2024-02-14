using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Logic.Interfaces
{
    public interface IBookingService
    {
        void AddBooking(BookingModel booking);
        BookingModel GetBookingById(string bookingId);
    }
}
