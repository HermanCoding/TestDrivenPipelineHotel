using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data
{
    public static class FakeDatabase
    {
        public static List<BookingModel>? Bookings { get; set; }
        public static List<RoomModel>? Rooms { get; set; }
        public static List<RoomTypeModel>? RoomTypes { get; set; }

    }
}
