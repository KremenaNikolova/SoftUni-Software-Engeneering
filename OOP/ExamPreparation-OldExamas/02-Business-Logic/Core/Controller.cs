using BookingApp.Core.Contracts;
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
                return $"Hotel {hotelName} is already registered in our platform.";
            }
            else
            {
                hotels.AddNew(hotel);
                return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
            }
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            throw new NotImplementedException();
        }

        public string HotelReport(string hotelName)
        {
            throw new NotImplementedException();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            throw new NotImplementedException();
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotels.All().Any(x=>x.FullName==hotelName))
            {
                //return $"Profile {hotelName} doesn’t exist!";
                return OutputMessages.HotelNameInvalid;
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

            hotels.AddNew(availableRoomAdd)
            return OutputMessages.RoomTypeAdded;

        }
    }
}
