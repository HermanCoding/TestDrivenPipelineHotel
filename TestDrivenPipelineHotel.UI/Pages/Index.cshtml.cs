using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TestDrivenPipelineHotel.UI.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public required string RoomType { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        public void OnGet()
        {
            FromDate = DateTime.Today;
            ToDate = DateTime.Today;
        }
    }
}
