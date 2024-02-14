using System.ComponentModel.DataAnnotations;

namespace TestDrivenPipelineHotel.Data.Models
{
    public class BookingModel
    {
        [Key]
        public required string BookingID { get; set; }
        public required DateTime DateFrom { get; set; }
        public required DateTime DateTo { get; set; }
        public required string RoomID { get; set; }
    }
}
