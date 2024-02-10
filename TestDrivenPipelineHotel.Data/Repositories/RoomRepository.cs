using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public void Add(RoomModel room)
        {
            FakeDatabase.Rooms.Add(room);
        }

        public List<RoomModel> GetAllRooms()
        {
            return FakeDatabase.Rooms;
        }
    }
}
