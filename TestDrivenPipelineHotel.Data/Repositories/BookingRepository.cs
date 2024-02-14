using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public void Add(BookingModel booking)
        {
            FakeDatabase.Bookings.Add(booking);
        }
        public BookingModel GetBookingById(string bookingId)
        {
            return FakeDatabase.Bookings.FirstOrDefault(b => b.BookingID == bookingId);
        }
    }
}
