using System.ComponentModel.DataAnnotations;

namespace TestDrivenPipelineHotel.Data.Models
{
    public class RoomTypeModel
    {
        [Key]
        public string TypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public List<RoomModel> Rooms { get; set; }
    }
}
