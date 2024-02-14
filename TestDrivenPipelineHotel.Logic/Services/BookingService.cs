using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;
using TestDrivenPipelineHotel.Logic.Interfaces;

namespace TestDrivenPipelineHotel.Logic.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void AddBooking(BookingModel booking)
        {
            _bookingRepository.Add(booking);
        }

        public BookingModel GetBookingById(string bookingId)
        {
            return _bookingRepository.GetBookingById(bookingId);
        }
    }
}
