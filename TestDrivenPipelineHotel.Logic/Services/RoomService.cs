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

        public List<RoomModel> SearchRoom(DateTime dateFrom, DateTime dateTo, string roomType)
        {
            throw new NotImplementedException();
        }
    }
}
