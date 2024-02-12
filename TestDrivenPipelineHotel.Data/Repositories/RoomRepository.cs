using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public Exception? RoomException { get; set; }

        public void Add(RoomModel room)
        {
            FakeDatabase.Rooms.Add(room);
        }

        public List<RoomModel> GetAllRooms()
        {
            return FakeDatabase.Rooms;
        }

        public RoomModel? GetRoomById(string id)
        {
            try { return FakeDatabase.Rooms.FirstOrDefault(room => room.RoomID == id); }


        }

    }
}
