﻿using TestDrivenPipelineHotel.Data.Interfaces;
using TestDrivenPipelineHotel.Data.Models;

namespace TestDrivenPipelineHotel.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public void Add(BookingModel booking)
        {
            FakeDatabase.Bookings.Add(booking);
        }

        public IEnumerable<BookingModel> GetAllBookings()
        {
            throw new NotImplementedException();
        }
    }
}
