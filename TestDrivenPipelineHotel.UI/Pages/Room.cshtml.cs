using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TestDrivenPipelineHotel.Data.Models;
using TestDrivenPipelineHotel.Logic.DTO;
using TestDrivenPipelineHotel.Logic.Interfaces;
using TestDrivenPipelineHotel.UI.ViewModels;

namespace TestDrivenPipelineHotel.UI.Pages
{
    public class RoomModel : PageModel
    {
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;

        public RoomDetailsViewModel RoomDetail { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RoomID { get; set; }

        [BindProperty(SupportsGet = true), DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [BindProperty(SupportsGet = true), DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        public RoomModel(IRoomService roomService, IBookingService bookingService)
        {
            _roomService = roomService;
            _bookingService = bookingService;
        }

        public void OnGet()
        {
            RoomDetailsDTO roomDetailsDto = _roomService.GetRoomDetails(RoomID);

            RoomDetail = new RoomDetailsViewModel
            {
                RoomID = roomDetailsDto.RoomID,
                TypeName = roomDetailsDto.TypeName,
                Price = roomDetailsDto.Price,
                Description = roomDetailsDto.Description,
            };
        }
        public IActionResult OnPost()
        {
            var booking = new BookingModel //Orkade inte bråka med DI längre :/ (Mycket strul)
            {
                BookingID = Guid.NewGuid().ToString(),
                DateFrom = FromDate,
                DateTo = ToDate,
                RoomID = RoomID
            };

            _bookingService.AddBooking(booking);

            return RedirectToPage("/Booked", new { bookingId = booking.BookingID });
        }
    }
}
