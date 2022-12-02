using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Repositories
{
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories.Contracts;

    public class RoomRepository : IRepository<IRoom>
    {
        private  List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            rooms.Add(model);
        }

        public IRoom Select(string criteria)
        {
            return rooms.Find(r => r.GetType().Name == criteria);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return rooms.AsReadOnly();
        }
    }
}
