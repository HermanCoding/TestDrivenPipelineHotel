using Microsoft.AspNetCore.Mvc.RazorPages;
using TestDrivenPipelineHotel.Logic.Interfaces;
using TestDrivenPipelineHotel.UI.ViewModels;

namespace TestDrivenPipelineHotel.UI.Pages
{
    public class RoomsModel : PageModel
    {
        private readonly IRoomService _roomService;
        public List<RoomDetailsViewModel> RoomDetails { get; set; }

        public RoomsModel(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public void OnGet()
        {
            var roomDetailsDTOs = _roomService.GetAllRoomDetails();
            RoomDetails = roomDetailsDTOs.Select(dto => new RoomDetailsViewModel
            {
                RoomID = dto.RoomID,
                TypeName = dto.TypeName,
                Price = dto.Price,
                Description = dto.Description
            }).ToList();
        }
    }
}
