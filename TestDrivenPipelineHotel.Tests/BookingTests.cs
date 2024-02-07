using FluentAssertions;
using TestDrivenPipelineHotel.Logic;

namespace TestDrivenPipelineHotel.Tests
{
    public class BookingTests
    {
        [Fact]
        public void SearchRoom_ReturnsListOfRooms()
        {
            //Given
            BookingLogic booking = new BookingLogic();
            var dateFrom = new DateTime(year: 2025, month: 05, day: 05);
            var dateTo = new DateTime(year: 2025, month: 05, day: 10);
            string roomType = "KingSize";


            //When
            var result = booking.SearchRoom(dateFrom, dateTo, roomType);

            //Then
            result.Should().NotBeNull();
        }
    }
}