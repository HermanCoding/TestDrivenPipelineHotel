using System.ComponentModel.DataAnnotations;

namespace TestDrivenPipelineHotel.Data.Models
{
    public class RoomModel
    {
        [Key]
        public required string RoomID { get; set; }
        public required string RoomTypeID { get; set; }
        public decimal? Price { get; set; }
    }
}
