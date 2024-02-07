using Microsoft.EntityFrameworkCore;
using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data
{
    public class HotelDbContext : DbContext
    {
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<RoomTypeModel> RoomTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDrivenPipelineHotel");
        }
    }
}
