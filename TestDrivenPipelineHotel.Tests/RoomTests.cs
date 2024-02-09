using FluentAssertions;
using TestDrivenPipelineHotel.Logic.Interfaces;
using TestDrivenPipelineHotel.Logic.Services;

namespace TestDrivenPipelineHotel.Tests
{
    public class RoomTests
    {
        private readonly IRoomService _roomService;

        [Fact]
        public void SearchRoom_ReturnsListOfRooms()
        {
            //Given
            RoomService searchLogic = new RoomService();
            var dateFrom = new DateTime(2024, 01, 01);
            var dateTo = new DateTime(2024, 01, 10);
            var roomType = _roomService.GetRoomTypeById("RT4");

            //When
            var searchedRooms = searchLogic.SearchRoom(dateFrom, dateTo, roomType);

            //Then
            searchedRooms.Should().NotBeNull();
        }
    }
}
