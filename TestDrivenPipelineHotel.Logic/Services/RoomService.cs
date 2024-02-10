using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;
using TestDrivenPipelineHotel.Logic.Interfaces;

namespace TestDrivenPipelineHotel.Logic.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<RoomModel> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public object GetRoomTypeById(string v)
        {
            throw new NotImplementedException();
        }


        public List<RoomModel> SearchRoom(DateTime dateFrom, DateTime dateTo, string roomType)
        {
            throw new NotImplementedException();
        }

        public object SearchRoom(DateTime dateFrom, DateTime dateTo, object roomType)
        {
            throw new NotImplementedException();
        }

        string IRoomService.GetRoomTypeById(string v)
        {
            throw new NotImplementedException();
        }
    }
}
