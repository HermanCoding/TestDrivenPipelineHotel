using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TestDrivenPipelineHotel.Logic.Interfaces;
using TestDrivenPipelineHotel.UI.ViewModels;

namespace TestDrivenPipelineHotel.UI.Pages
{
    public class AvailableRoomsModel : PageModel
    {
        private readonly IRoomService _roomService;
        public List<RoomDetailsViewModel> RoomDetails { get; set; } = new List<RoomDetailsViewModel>();

        [BindProperty(SupportsGet = true)]
        public string RoomType { get; set; }

        [BindProperty(SupportsGet = true), DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [BindProperty(SupportsGet = true), DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        public AvailableRoomsModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public IActionResult OnGet()
        {
            try
            {
                var roomDetailsDTOs = _roomService.GetAllRoomDetails(_roomService.SearchRooms(FromDate, ToDate, RoomType));
                RoomDetails = roomDetailsDTOs.Select(dto => new RoomDetailsViewModel
                {
                    RoomID = dto.RoomID,
                    TypeName = dto.TypeName,
                    Price = dto.Price,
                    Description = dto.Description
                }).ToList();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return Page();
        }
    }
}