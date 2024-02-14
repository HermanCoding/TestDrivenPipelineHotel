using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data.Interfaces
{
    public interface IBookingRepository
    {
        public void Add(BookingModel booking);
        public BookingModel GetBookingById(string bookingId);
    }
}
