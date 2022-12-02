using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Core
{
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using BookingApp.Core.Contracts;
    using BookingApp.Models.Bookings;
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Hotels;
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Models.Rooms;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IHotel> hotelRepository;

        public Controller()
        {
            hotelRepository = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotelRepository.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotel = new Hotel(hotelName, category);
            hotelRepository.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotelRepository.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotelRepository.All().First(h => h.FullName == hotelName);

            var rooms = hotel.Rooms.All();

            if (rooms.Any(h => h.GetType().Name == roomTypeName))
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            IRoom roomToAdd;

            if (roomTypeName == "Apartment")
            {
                roomToAdd = new Apartment();
            }
            else if (roomTypeName == "DoubleBed")
            {
                roomToAdd = new DoubleBed();
            }
            else if (roomTypeName == "Studio")
            {
                roomToAdd = new Studio();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotel.Rooms.AddNew(roomToAdd);

            return string.Format(OutputMessages.RoomTypeAdded,roomTypeName,hotelName);

        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!hotelRepository.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (!new string[] { "Apartment", "DoubleBed", "Studio" }.Contains(roomTypeName))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            IHotel hotel = hotelRepository.All().First(h => h.FullName == hotelName);
            if (!hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            IRoom room = hotel.Rooms.All().First(r => r.GetType().Name == roomTypeName);

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }
            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (!hotelRepository.All().Any(h => h.Category == category))
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            var avaliableRooms = new List<IRoom>();

            foreach (var hotel in hotelRepository.All().Where(h=>h.Category == category).OrderBy(h=>h.FullName))
            {
                foreach (var room in hotel.Rooms.All())
                {
                    if (room.PricePerNight != 0)
                    {
                        avaliableRooms.Add(room);
                    }
                }
            }

            IRoom roomToBook = null;
            

            int people = adults + children;

            foreach (var room in avaliableRooms.OrderBy(r=>r.BedCapacity))
            {
                if (room.BedCapacity >= people)
                {
                    roomToBook = room;
                    break;
                }
            }

            if (roomToBook == null)
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }

            IHotel hotelToBook = hotelRepository.All().First(h=>h.Category == category);

            int newBookingNumber = hotelToBook.Bookings.All().Count+ 1;

            IBooking newBooking = new Booking(roomToBook, duration, adults, children, newBookingNumber);

            hotelToBook.Bookings.AddNew(newBooking);
            string hotelName = hotelToBook.FullName;
            return string.Format(OutputMessages.BookingSuccessful, newBookingNumber,hotelName );
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotelRepository.Select(hotelName);
            if (hotel == null)
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                sb.Append("none");
                return sb.ToString();
            }
            foreach (var booking in hotel.Bookings.All())
            {
                sb.AppendLine(booking.BookingSummary());
            }

            return sb.ToString().Trim();
        }
    }
}
