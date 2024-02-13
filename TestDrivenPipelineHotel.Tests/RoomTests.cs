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
        public void GetAllRooms_ShouldReturnARoomR3InResult_ReturnsCorrectRoomData()
        {
            // Given
            // Setup in constructor

            // When
            var rooms = _roomService.GetAllRooms();

            // Then
            var expectedId = "R3";
            rooms.Should().ContainSingle(room => room.RoomID == expectedId);
        }

        [Fact]
        public void GetAllRooms_WithNoRooms_ReturnsEmptyList()
        {
            // Given
            // Setup in constructor
            FakeDatabase.Rooms.Clear();

            // When
            var rooms = _roomService.GetAllRooms();

            // Then
            rooms.Should().BeEmpty();
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

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("\t")]
        public void GetRoom_WithNullOrWhitespaceId_ThrowsInvalidDataException(string roomId)
        {
            // Given setup in constructor

            // When
            Action action = () => _roomService.GetRoom(roomId);

            // Then
            action.Should().Throw<InvalidDataException>().WithMessage("RoomID cannot be null or an empty string.");
        }

        [Fact]
        public void GetRoom_ShouldTrowKeyNotFoundException()
        {
            // Given
            // Setup in constructor
            var roomID = "FelID";

            // When
            Action action = () => _roomService.GetRoom(roomID);

            // Then
            action.Should().Throw<KeyNotFoundException>($"No room found with ID {roomID}.");
        }

        [Theory]
        [InlineData("R2")]
        [InlineData("R3")]
        public void GetRoom_WithValidId_ReturnsExpectedRoom(string roomId)
        {
            // Given
            // Setup in constructor

            // When
            var room = _roomService.GetRoom(roomId);

            // Then
            room.Should().NotBeNull();
            room.RoomID.Should().Be(roomId);
        }

        [Fact]
        public void SearchRooms_ReturnsListOfRoomsWithType()
        {
            // Given
            // Setup in constructor
            DateTime dateFrom = DateTime.Now.AddMinutes(30);
            DateTime dateTo = DateTime.Now.AddMinutes(30).AddDays(3);
            string roomType = "Twin";

            // When
            var rooms = _roomService.SearchRooms(dateFrom, dateTo, roomType);

            // Then
            rooms.Should().NotBeNullOrEmpty();
            rooms.Should().BeOfType<List<RoomModel>>();
        }


        [Fact]
        public void SearchRooms_NoRoomAvailableBookingConflict_ThrowsArgumentException()
        {
            // Given
            // Setup in constructor
            DateTime dateFrom = DateTime.Now;
            DateTime dateTo = DateTime.Now.AddDays(5);
            string roomType = "Suite";
            // When
            Action action = () => _roomService.SearchRooms(dateFrom, dateTo, roomType);

            // Then
            action.Should().Throw<ArgumentException>("No available room(s) found with your search criteria.");
        }

        [Fact]
        public void SearchRooms_DateInPast_InvalidDataException()
        {
            // Given
            // Setup in constructor
            DateTime dateFrom = DateTime.Now.AddDays(-2);
            DateTime dateTo = DateTime.Now.AddDays(5);
            string roomType = "Double";
            // When
            Action action = () => _roomService.SearchRooms(dateFrom, dateTo, roomType);

            // Then
            action.Should().Throw<InvalidDataException>();
        }

        [Fact]
        public void SearchRooms_DateToBeforeDateFrom_InvalidDataException()
        {
            // Given
            // Setup in constructor
            DateTime dateFrom = DateTime.Now;
            DateTime dateTo = DateTime.Now.AddDays(-1);
            string roomType = "Double";
            // When
            Action action = () => _roomService.SearchRooms(dateFrom, dateTo, roomType);

            // Then
            action.Should().Throw<InvalidDataException>();
        }

        [Fact]
        public void SearchRooms_RoomTypeDoesNotExist_ThrowsArgumentException()
        {
            // Given
            // Setup in constructor
            var dateFrom = DateTime.Now.AddDays(1);
            var dateTo = DateTime.Now.AddDays(4);
            var roomType = "NonExistentType";

            // When
            Action action = () => _roomService.SearchRooms(dateFrom, dateTo, roomType);

            // Then
            action.Should().Throw<ArgumentException>("No available room(s) found with your search criteria.");
        }

        [Fact]
        public void SearchRooms_DateRangeOverlapsButRoomsAvailable_ReturnsAvailableRooms()
        {
            // Given
            // Setup in constructor
            DateTime dateFrom = DateTime.Now;
            DateTime dateTo = DateTime.Now.AddDays(5);
            string roomType = "Single";

            // When
            var rooms = _roomService.SearchRooms(dateFrom, dateTo, roomType);

            // Then
            rooms.Should().NotBeEmpty("because there should be available rooms even with overlapping bookings");
        }

        [Fact]
        public void SearchRooms_DateRangeIsSameDay_ReturnsListOfRoomsWithType()
        {
            // Given
            // Setup in constructor
            DateTime dateFrom = DateTime.Now.AddDays(1);
            DateTime dateTo = dateFrom;
            string roomType = "Twin";

            // When
            var rooms = _roomService.SearchRooms(dateFrom, dateTo, roomType);

            // Then
            rooms.Should().NotBeNullOrEmpty("because rooms should be available for bookings starting and ending on the same day");
        }

        [Fact]
        public void SearchRooms_RoomTypeIsWhitespace_ThrowsInvalidDataException()
        {
            // Given
            // Setup in constructor
            DateTime dateFrom = DateTime.Now.AddDays(1);
            DateTime dateTo = DateTime.Now.AddDays(2);
            string roomType = "   "; // Whitespace string

            // When
            Action action = () => _roomService.SearchRooms(dateFrom, dateTo, roomType);

            // Then
            action.Should().Throw<InvalidDataException>("because room type cannot be a whitespace string");
        }
    }
}
