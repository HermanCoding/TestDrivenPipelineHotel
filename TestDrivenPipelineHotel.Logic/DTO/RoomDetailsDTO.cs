namespace TestDrivenPipelineHotel.Logic.DTO
{
    public class RoomDetailsDTO
    {
        public required string RoomID { get; set; }
        public required string TypeName { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}
