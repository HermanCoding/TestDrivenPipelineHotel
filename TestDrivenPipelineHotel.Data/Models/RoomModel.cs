using System.ComponentModel.DataAnnotations;

namespace TestDrivenPipelineHotel.Data.Models
{
    public class RoomModel
    {
        [Key]
        public string RoomID { get; set; }
        public string RoomTypeID { get; set; }
        public RoomTypeModel RoomType { get; set; }
        public decimal Price { get; set; }
        public List<BookingModel> Bookings { get; set; }
    }
}
