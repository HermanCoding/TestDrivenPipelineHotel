using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data.Repositories
{
    public interface IBookingRepository
    {
        public IEnumerable<BookingModel> GetAllBookings();

        public void PostBooking(BookingModel booking);

        public void DeleteBookingById(int id);
    }
}
