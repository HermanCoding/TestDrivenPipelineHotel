using FluentAssertions;
using TestDrivenPipelineHotel.Data;
using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;
using TestDrivenPipelineHotel.Data.Repositories;
using TestDrivenPipelineHotel.Logic.Services;

namespace TestDrivenPipelineHotel.Tests
{
    public class BookingTests : IDisposable
    {
        public BookingTests()
        {
            IRoomRepository roomRepository = new RoomRepository();
            IRoomTypeRepository roomTypeRepository = new RoomTypeRepository();
            IBookingRepository bookingRepository = new BookingRepository();
            TestDataInitializer.Initialize(roomRepository, bookingRepository, roomTypeRepository);
        }
        public void Dispose()
        {
            FakeDatabase.Bookings.Clear();
            FakeDatabase.Rooms.Clear();
            FakeDatabase.RoomTypes.Clear();
        }

        [Fact]
        public void AddBooking_ShouldAddBooking_WhenCalledWithValidData()
        {
            // Given
            var service = new BookingService(new BookingRepository());
            var newBooking = new BookingModel
            {
                BookingID = "TestBooking",
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(1),
                RoomID = "R1"
            };

            // When
            service.AddBooking(newBooking);

            // Then
            var addedBooking = FakeDatabase.Bookings.Should().ContainSingle(b => b.BookingID == "TestBooking").Subject;
            addedBooking.RoomID.Should().Be("R1");
        }

        [Fact]
        public void GetBookingById_ShouldReturnCorrectBooking_WhenBookingExists()
        {
            // Given
            var service = new BookingService(new BookingRepository());
            var expectedBookingId = "B1"; // Assuming B1 is added in TestDataInitializer

            // When
            var booking = service.GetBookingById(expectedBookingId);

            // Then
            booking.Should().NotBeNull();
            booking.BookingID.Should().Be(expectedBookingId);
        }

        [Fact]
        public void GetBookingById_ShouldReturnNull_WhenBookingDoesNotExist()
        {
            // Given
            var service = new BookingService(new BookingRepository());

            // When
            var booking = service.GetBookingById("NonExistentBooking");

            // Then
            booking.Should().BeNull();
        }
    }
}