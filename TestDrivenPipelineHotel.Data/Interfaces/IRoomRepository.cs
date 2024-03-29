﻿using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data.Interfaces
{
    public interface IRoomRepository
    {
        public void Add(RoomModel room);
        List<RoomModel> GetAllRooms();
        public RoomModel? GetRoomById(string id);
    }
}
