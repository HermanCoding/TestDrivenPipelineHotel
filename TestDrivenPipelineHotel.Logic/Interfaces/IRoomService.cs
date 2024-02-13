using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Logic.Interfaces
{
    public interface IRoomService
    {
        List<RoomModel> GetAllRooms();
        public RoomModel GetRoom(string roomID);
        List<RoomModel> SearchRooms(DateTime dateFrom, DateTime dateTo, string roomType);
    }
}
