using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultCount, int childrenCount, int bookingNumber)
        {
            this.room = room;
            ResidenceDuration= residenceDuration;
            AdultsCount= adultCount;
            ChildrenCount= childrenCount;
            this.bookingNumber = bookingNumber;
        }
        public IRoom Room => room;

        public int ResidenceDuration
        {
            get => residenceDuration;
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                residenceDuration = value;
            }
        }

        public int AdultsCount 
        {
            get => adultCount;
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                adultCount = value;
            }
        }

        public int ChildrenCount
        {
            get => childrenCount;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                childrenCount = value;
            }
        }

        public int BookingNumber => bookingNumber;

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();
            

            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {Total():F2} $");

            return sb.ToString();
        }

        private double Total() => Math.Round(ResidenceDuration* room.PricePerNight, 2);
    }
}
