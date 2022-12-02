using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Repositories
{
    using System.Linq;
    using BookingApp.Models.Hotels;
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Repositories.Contracts;

    public class HotelRepository : IRepository<IHotel>
    {
        private  List<IHotel> hotels;

        public HotelRepository()
        {
            hotels = new List<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            hotels.Add(model);
        }

        public IHotel Select(string criteria)
        {
            return hotels.Find(h => h.FullName == criteria);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return hotels.AsReadOnly();
        }
    }
}
