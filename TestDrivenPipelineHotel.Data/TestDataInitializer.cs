using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data
{
    public static class TestDataInitializer
    {
        public static void Initialize(IRoomRepository roomRepository, IBookingRepository bookingRepository, IRoomTypeRepository roomTypeRepository)
        {
            roomRepository.Add(new RoomModel { RoomID = "R1", RoomTypeID = "RT1", Price = 100 });
            roomRepository.Add(new RoomModel { RoomID = "R2", RoomTypeID = "RT2", Price = 200 });
            roomRepository.Add(new RoomModel { RoomID = "R3", RoomTypeID = "RT3", Price = 250 });
            roomRepository.Add(new RoomModel { RoomID = "R4", RoomTypeID = "RT4", Price = 400 });
            roomRepository.Add(new RoomModel { RoomID = "R5", RoomTypeID = "RT5", Price = 600 });
            roomRepository.Add(new RoomModel { RoomID = "R6", RoomTypeID = "RT1", Price = 100 });
            roomRepository.Add(new RoomModel { RoomID = "R7", RoomTypeID = "RT2", Price = 200 });
            roomRepository.Add(new RoomModel { RoomID = "R8", RoomTypeID = "RT3", Price = 250 });

            roomTypeRepository.Add(new RoomTypeModel { TypeID = "RT2", TypeName = "Double", Description = "A double room" });
            roomTypeRepository.Add(new RoomTypeModel { TypeID = "RT3", TypeName = "Twin", Description = "A twin room" });
            roomTypeRepository.Add(new RoomTypeModel { TypeID = "RT4", TypeName = "Deluxe", Description = "A deluxe room" });
            roomTypeRepository.Add(new RoomTypeModel { TypeID = "RT1", TypeName = "Single", Description = "A single room" });
            roomTypeRepository.Add(new RoomTypeModel { TypeID = "RT5", TypeName = "Suite", Description = "A suite room" });

            bookingRepository.Add(new BookingModel { BookingID = "B1", DateFrom = new DateTime(2024, 02, 01), DateTo = new DateTime(2024 - 02 - 07), RoomID = "R1" });
            bookingRepository.Add(new BookingModel { BookingID = "B2", DateFrom = new DateTime(2024, 02, 05), DateTo = new DateTime(2024 - 02 - 09), RoomID = "R2" });
            bookingRepository.Add(new BookingModel { BookingID = "B3", DateFrom = new DateTime(2024, 02, 10), DateTo = new DateTime(2024 - 02 - 17), RoomID = "R1" });
        }
    }
}
