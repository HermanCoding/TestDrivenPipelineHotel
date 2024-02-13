using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Logic.Interfaces
{
    public interface IRoomService
    {
        List<RoomModel> GetAllRooms();
        public RoomModel GetRoom(string roomID);
    }
}
