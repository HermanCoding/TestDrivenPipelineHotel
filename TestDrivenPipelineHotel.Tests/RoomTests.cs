using FluentAssertions;
using TestDrivenPipelineHotel.Data;
using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;
using TestDrivenPipelineHotel.Data.Repositories;
using TestDrivenPipelineHotel.Logic.Interfaces;
using TestDrivenPipelineHotel.Logic.Services;

namespace TestDrivenPipelineHotel.Tests
{
    public class RoomTests : IDisposable
    {
        private readonly IRoomService _roomService;

        public RoomTests()
        {
            IRoomRepository roomRepository = new RoomRepository();
            IRoomTypeRepository roomTypeRepository = new RoomTypeRepository();
            IBookingRepository bookingRepository = new BookingRepository();
            _roomService = new RoomService(roomRepository, roomTypeRepository);
            TestDataInitializer.Initialize(roomRepository, bookingRepository, roomTypeRepository);
        }

        public void Dispose()
        {
            FakeDatabase.Bookings.Clear();
            FakeDatabase.Rooms.Clear();
            FakeDatabase.RoomTypes.Clear();
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

        [Fact]
        public void GetRoom_ReturnsRoomModel()
        {
            // Given
            // Setup in constructor
            var roomID = "R1";

            // When
            var room = _roomService.GetRoom(roomID);

            // Then
            room.Should().NotBeNull();
            room.Should().BeOfType<RoomModel>();
        }

        [Fact]
        public void GetRoom_ShouldTrowException()
        {
            // Given
            // Setup in constructor
            var roomID = "";

            // When
            var room = _roomService.GetRoom(roomID);

            // Then
            room.Should().BeOfType<ArgumentException>();
        }
        // Given
        // Setup in constructor
        // When
        // Then
    }
}
