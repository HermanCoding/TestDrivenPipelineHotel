using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public void Add(RoomTypeModel roomType)
        {
            FakeDatabase.RoomTypes.Add(roomType);
        }
    }
}
