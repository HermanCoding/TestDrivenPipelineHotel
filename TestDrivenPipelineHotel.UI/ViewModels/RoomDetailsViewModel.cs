namespace TestDrivenPipelineHotel.UI.ViewModels
{
    public class RoomDetailsViewModel
    {
        public required string RoomID { get; set; }
        public required string TypeName { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}
