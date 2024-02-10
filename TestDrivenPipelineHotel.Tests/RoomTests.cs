using FluentAssertions;
using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;
using TestDrivenPipelineHotel.Data.Repositories;
using TestDrivenPipelineHotel.Logic.Interfaces;
using TestDrivenPipelineHotel.Logic.Services;

namespace TestDrivenPipelineHotel.Tests
{
    public class RoomTests
    {
        private readonly IRoomService _roomService;

        public RoomTests()
        {
            IRoomRepository roomRepository = new RoomRepository();
            _roomService = new RoomService(roomRepository);
        }


        [Fact]
        public void GetAllRooms_ReturnsListOfRooms()
        {
            // Given
            // Setup in constructor

            // When
            var rooms = _roomService.GetAllRooms();
            // Then
            rooms.Should().NotBeNullOrEmpty();
            rooms.Should().BeOfType<List<RoomModel>>();
        }
    }
}
