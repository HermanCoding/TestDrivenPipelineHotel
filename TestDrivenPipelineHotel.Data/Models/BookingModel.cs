using System.ComponentModel.DataAnnotations;

namespace TestDrivenPipelineHotel.Data.Models
{
    public class BookingModel
    {
        [Key]
        public string BookingID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string RoomID { get; set; }
        public RoomModel Room { get; set; }
    }
}
