using TestDrivenPipelineHotel.Data;
using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;
using TestDrivenPipelineHotel.Logic.Interfaces;

namespace TestDrivenPipelineHotel.Logic.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<RoomModel> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public RoomModel GetRoom(string roomID)
        {
            // You shall not pass!! (guard clause)
            if (string.IsNullOrWhiteSpace(roomID))
            {
                throw new InvalidDataException("RoomID cannot be null or an empty string.");
            }

            var room = _roomRepository.GetRoomById(roomID);
            if (room == null)
            {
                throw new KeyNotFoundException($"No room found with ID {roomID}.");
            }

            return room;
        }

        public List<RoomModel> SearchRooms(DateTime dateFrom, DateTime dateTo, string roomType)
        {
            // You shall not pass!! (guard clause)
            if (string.IsNullOrWhiteSpace(roomType))
            {
                throw new InvalidDataException("RoomType cannot be null or an empty string.");
            }
            if (dateFrom < DateTime.Today) //Should probably be Now but thats a later problem.
            {
                throw new InvalidDataException("The 'dateFrom' cant be in the past.");
            }
            if (dateFrom > dateTo)
            {
                throw new InvalidDataException("The 'dateFrom' must be before 'dateTo'.");
            }

            // fetch all rooms
            var allRooms = _roomRepository.GetAllRooms();

            // Filter based on room type
            var filteredRoomsByType = allRooms.Where(room =>
                FakeDatabase.RoomTypes.Any(rt => rt.TypeID == room.RoomTypeID && rt.TypeName == roomType)).ToList();

            // Filter booked rooms
            var availableRooms = filteredRoomsByType.Where(room =>
                !FakeDatabase.Bookings.Any(booking =>
                    booking.RoomID == room.RoomID &&
                    ((dateFrom < booking.DateTo && dateTo > booking.DateFrom) || // Overlapping current booking
                     (dateFrom == booking.DateFrom || dateTo == booking.DateTo)) // Identical booking already exists
                )).ToList();

            if (availableRooms.Count == 0)
            {
                throw new ArgumentException("No available room(s) found with your search criteria.");
            }

            return availableRooms;
        }
    }
}
