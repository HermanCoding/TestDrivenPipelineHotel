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
        public List<RoomDetailsViewModel> RoomDetails { get; set; }

        public AvailableRoomsModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [BindProperty(SupportsGet = true)]
        public string RoomType { get; set; }

        [BindProperty(SupportsGet = true), DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [BindProperty(SupportsGet = true), DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        public void OnGet()
        {
            // Your logic here, e.g., fetching available rooms based on the parameters
        }
    }
}