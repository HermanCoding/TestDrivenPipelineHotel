using System.ComponentModel.DataAnnotations;

namespace TestDrivenPipelineHotel.Data.Models
{
    public class RoomTypeModel
    {
        [Key]
        public required string TypeID { get; set; }
        public required string TypeName { get; set; }
        public string? Description { get; set; }
    }
}
