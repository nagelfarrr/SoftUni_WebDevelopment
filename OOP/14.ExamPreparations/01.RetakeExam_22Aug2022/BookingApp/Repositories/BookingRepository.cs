using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Repositories
{
    using System.Linq;
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Repositories.Contracts;

    public class BookingRepository : IRepository<IBooking>
    {
        private  List<IBooking> bookings;

        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            bookings.Add(model);
        }

        public IBooking Select(string criteria)
        {
            return bookings.Find(b => b.BookingNumber.ToString() == criteria);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return bookings.AsReadOnly();
        }
    }
}
