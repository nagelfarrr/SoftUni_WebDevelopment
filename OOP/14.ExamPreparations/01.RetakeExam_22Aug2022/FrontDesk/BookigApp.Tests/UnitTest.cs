using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;


    public class Tests
    {
        private Room room;
        private Booking booking;
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            room = new Room(3, 20);
            booking = new Booking(1, room, 2);
            hotel = new Hotel("Dobrudja", 2);
        }

        [Test]
        public void ConstructorShoulInitializeProperly()
        {
            Hotel hotel = new Hotel("Dobrudja", 2);

            Assert.AreEqual("Dobrudja", hotel.FullName);
            Assert.AreEqual(2, hotel.Category);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("          ")]
        public void HotelFullNameShouldThrowExceptionWhenNullOrWhiteSpace(string fullname)
        {


            Assert.Throws<ArgumentNullException>((() =>
            {
                Hotel hotel = new Hotel(fullname, 2);
            }));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(6)]
        [TestCase(10)]
        public void HotelCategoryShouldBeBetweenZeroAndSixExclusive(int category)
        {
            Assert.Throws<ArgumentException>((() =>
            {
                Hotel hotel = new Hotel("Dobrudja", category);
            }));
        }

        [Test]
        public void HotelTurnoverShouldBeZeroByDefault()
        {

            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void HotelRoomsShouldReturnReadOnlyCollection()
        {

            Assert.That(hotel.Rooms is IReadOnlyCollection<Room>);
        }

        [Test]
        public void HotelBookingShouldReturnReadOnlyCollection()
        {
            Assert.That(hotel.Bookings is IReadOnlyCollection<Booking>);
        }

        [Test]
        public void HotelShouldAddRoomToTheCollection()
        {
            hotel.AddRoom(room);

            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [Test]
        public void HotelShouldAddMultipleRoomsToTheCollection()
        {
            hotel.AddRoom(room);
            hotel.AddRoom(room);
            hotel.AddRoom(room);
            hotel.AddRoom(room);

            Assert.AreEqual(4, hotel.Rooms.Count);

        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void BookRoomShouldThrowExceptionWhenNoAdultsArePresent(int adults)
        {
            int children = 2;
            int residenceDuration = 3;
            double budget = 20;


            Assert.Throws<ArgumentException>((() =>
            {
                hotel.BookRoom(adults, children, residenceDuration, budget);
            }));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void BookRoomShouldThrowExceptionWhenChildrenAreBelowZero(int children)
        {
            int adults = 2;
            int residenceDuration = 3;
            double budget = 20;


            Assert.Throws<ArgumentException>((() =>
            {
                hotel.BookRoom(adults, children, residenceDuration, budget);
            }));
        }


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void BookRoomShouldThrowExceptionWhenResidenceDurationsIsZeroOrBelow(int residenceDuration)
        {
            int adults = 2;
            int children = 3;
            double budget = 20;


            Assert.Throws<ArgumentException>((() =>
            {
                hotel.BookRoom(adults, children, residenceDuration, budget);
            }));
        }

        [Test]
        public void BookRoomNeededBedShouldBeTheSumOfAdultsAndChildren()
        {
            int adults = 3;
            int children = 1;
            
            hotel.AddRoom(room); //room capacity is 3
            hotel.BookRoom(adults,children,3,60);//budget is enough for booking

            Assert.AreEqual(0,hotel.Bookings.Count);
        }

        [Test]
        public void RoomsShouldBeOrderedByBedCapacityWhenTryingToBook()
        {
            room = new Room(1, 20);
            Room room2 = new Room(2, 20);
            Room room3 = new Room(3, 20);

            hotel.AddRoom(room3);
            hotel.AddRoom(room);
            hotel.AddRoom(room2);

            hotel.BookRoom(1,0,3,60);

            var expectedBookedRoom = room;

            var booking = hotel.Bookings.First();

            var actualBookedRoom = booking.Room;
            Assert.AreEqual(expectedBookedRoom,actualBookedRoom);

        }

        [TestCase(4)]
        [TestCase(5)]
        public void RoomBedCapacityShouldBeEqualOrHigherThanVisitors(int bedCapacity)
        {
            int adults = 2;
            int children = 2;

            Room roomToBook = new Room(bedCapacity, 20);

            hotel.AddRoom(roomToBook);

            hotel.BookRoom(adults,children,3,60);

            Assert.AreEqual(1,hotel.Bookings.Count);
        }

        [Test]
        public void CannotBookRoomWhenBedCapacityIsLessThanVisitors()
        {
            int adults = 1;
            int children = 1;
            Room roomToBook = new Room(1, 20);
            hotel.AddRoom(roomToBook);

            hotel.BookRoom(adults,children,3,60);
            
            Assert.AreEqual(0,hotel.Bookings.Count);
        }

        [Test]
        public void HotelBookingsCountIncreaseAfterSuccessfulBooking()
        {
            hotel.AddRoom(room);
            
            hotel.BookRoom(1, 0, 3, 60);
            hotel.BookRoom(1, 1, 3, 60);
            hotel.BookRoom(1, 2, 3, 60);

            Assert.AreEqual(3,hotel.Bookings.Count);

        }

        [Test]
        public void HotelTurnOverShouldIncreaseAfterSuccessfulBooking()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1,0,3,60);

            double expectedTurnOver = room.PricePerNight * 3;

            Assert.AreEqual(expectedTurnOver, hotel.Turnover);
        }
    }
}