using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data.Interfaces
{
    public interface IBookingRepository
    {
        public IEnumerable<BookingModel> GetAllBookings();

        public void Add(BookingModel booking);
    }
}
