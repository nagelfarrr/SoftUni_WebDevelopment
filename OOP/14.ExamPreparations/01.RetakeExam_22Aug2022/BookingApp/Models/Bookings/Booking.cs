using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Utilities.Messages;

    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }

        public IRoom Room
        {
            get => this.room;
            private set
            {
                this.room = value;
            }
        }

        public int ResidenceDuration
        {
            get => this.residenceDuration;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }

                this.residenceDuration = value;
            }
        }
        public int AdultsCount
        {
            get => this.adultsCount;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }

                this.adultsCount = value;
            }
        }
        public int ChildrenCount
        {
            get => this.childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                this.childrenCount = value;
            }
        }
        public int BookingNumber { get; private set; }
        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            sb.AppendLine($"Total amount paid: {TotalPaid():F2} $");

            return sb.ToString().Trim();

        }

        public double TotalPaid() => Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);



    }
}
