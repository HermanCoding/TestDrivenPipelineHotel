using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data
{
    public static class FakeDatabase
    {
        public static List<BookingModel> Bookings { get; set; } = new List<BookingModel>();
        public static List<RoomModel> Rooms { get; set; } = new List<RoomModel>();
        public static List<RoomTypeModel> RoomTypes { get; set; } = new List<RoomTypeModel>();

    }
}
