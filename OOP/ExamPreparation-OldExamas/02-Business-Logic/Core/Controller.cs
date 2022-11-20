using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace _02_Business_Logic.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            Hotel hotel = new Hotel(hotelName, category);
            if (hotels.All().Any(x=>x.FullName==hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            else
            {
                hotels.AddNew(hotel);
                return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
            }
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (!hotels.All().Any(x=>x.Category==category))
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
            

            Dictionary<IRoom, string> availibleRooms = new Dictionary<IRoom, string>();
            foreach (var hotel in hotels.All().Where(x=>x.Category==category).OrderBy(x=>x.FullName))
            {
                foreach (var room in hotel.Rooms.All())
                {
                    if (room.PricePerNight>0)
                    {
                        availibleRooms.Add(room, hotel.FullName);
                    }
                }
            }

            int allGuests = adults + children;
            IRoom booking = null;
            string hotelNameBooking = string.Empty;
            
            foreach (var room in availibleRooms.OrderBy(x=>x.Key.BedCapacity))
            {
                if (room.Key.BedCapacity>allGuests)
                {
                    booking = room.Key;
                    hotelNameBooking = room.Value;
                    break;
                }
            }

            if (booking==null)
            {
                return OutputMessages.RoomNotAppropriate;
            }

            IHotel hotelBook = hotels.Select(hotelNameBooking);
            int bookingNumber = hotelBook.Bookings.All().Count + 1;

            Booking succsessfullBooking = new Booking(booking, duration, adults, children, bookingNumber);
            hotelBook.Bookings.AddNew(succsessfullBooking);

            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotelNameBooking);
        }

        public string HotelReport(string hotelName)
        {
            StringBuilder sb = new StringBuilder();
            IHotel hotel = hotels.Select(hotelName);
            if (!hotels.All().Any(x=>x.FullName==hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category}");
            sb.AppendLine($"--Turnover: {hotel.Turnover:f2}$");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings==null)
            {
                sb.AppendLine("none");
                return sb.ToString().TrimEnd();
            }

            foreach (var booking in hotel.Bookings.All())
            {
                sb.AppendLine(booking.BookingSummary());
            }

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!hotels.All().Any(x=>x.FullName==hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (!new string[] { "Apartment", "DoubleBed", "Studio" }.Contains(roomTypeName))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IHotel hotel = hotels.All().First(x=>x.FullName== hotelName);
            bool rooms = hotel.Rooms.All().Any(x=>x.GetType().Name == roomTypeName);
            if (!rooms)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            IRoom room = hotel.Rooms.All().First(x => x.GetType().Name == roomTypeName);
            if (room.PricePerNight!=0)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
            }
            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
            
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotels.All().Any(x=>x.FullName==hotelName))
            {
                //return $"Profile {hotelName} doesn’t exist!";
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }


            IHotel hotel = hotels.All().First(x=>x.FullName==hotelName);
            bool rooms = hotel.Rooms.All().Any(x=>x.GetType().Name == roomTypeName);
            if (rooms)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            IRoom availableRoomAdd;
            switch (roomTypeName)
            {
                case "Apartment": availableRoomAdd = new Apartment(); break;
                case "DoubleBed": availableRoomAdd = new DoubleBed(); break;
                case "Studio": availableRoomAdd = new Studio(); break;
                default: throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotel.Rooms.AddNew(availableRoomAdd);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);

        }
    }
}
