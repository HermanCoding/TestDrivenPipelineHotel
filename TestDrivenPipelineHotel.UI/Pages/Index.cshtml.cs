using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TestDrivenPipelineHotel.Logic.Interfaces;

namespace TestDrivenPipelineHotel.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;

        public IndexModel(IRoomService roomService, IBookingService bookingService)
        {
            _roomService = roomService;
            _bookingService = bookingService;
        }

        [BindProperty]
        public required string RoomType { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        public void OnGet()
        {
            FromDate = DateTime.Today;
            ToDate = DateTime.Today.AddDays(1);
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/AvailableRooms", new { RoomType, FromDate, ToDate });
        }
    }
}
