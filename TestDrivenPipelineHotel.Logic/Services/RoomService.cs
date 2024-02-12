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

        public RoomModel GetRoom(string roomId)
        {
            try
            {
                return _roomRepository.GetRoomById(roomId);
            }
            catch (Exception)
            {
                throw new ArgumentException(); // TODO Vet inte om det är detta jag vill retunera.
            }

        }

        public List<RoomModel> SearchRoom(DateTime dateFrom, DateTime dateTo, string roomType)
        {
            throw new NotImplementedException();
        }
    }
}
