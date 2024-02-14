using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestDrivenPipelineHotel.Data.Models;
using TestDrivenPipelineHotel.Logic.Interfaces;

namespace TestDrivenPipelineHotel.UI.Pages
{
    public class BookedModel : PageModel
    {
        private readonly IBookingService _bookingService;

        [BindProperty(SupportsGet = true)]
        public string BookingID { get; set; }

        public BookingModel BookingDetails { get; set; }

        public BookedModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public void OnGet()
        {

            BookingDetails = _bookingService.GetBookingById(BookingID);
        }
    }
}
