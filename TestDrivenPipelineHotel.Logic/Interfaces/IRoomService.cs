using TestDrivenPipelineHotel.Data.Models;
using TestDrivenPipelineHotel.Logic.DTO;

namespace TestDrivenPipelineHotel.Logic.Interfaces
{
    public interface IRoomService
    {
        List<RoomModel> GetAllRooms();
        public List<RoomDetailsDTO> GetAllRoomDetails(List<RoomModel>? input);
        public RoomModel GetRoom(string roomID);
        List<RoomModel> SearchRooms(DateTime dateFrom, DateTime dateTo, string roomType);
    }
}
