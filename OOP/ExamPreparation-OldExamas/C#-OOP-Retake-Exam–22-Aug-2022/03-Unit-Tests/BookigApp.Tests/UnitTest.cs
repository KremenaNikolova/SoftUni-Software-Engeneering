using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        Room room;
        Booking booking;
        Hotel hotel;

        [SetUp]
        public void Setup()
        {
            room = new Room(3, 45);
            booking = new Booking(132, room, 5);
            hotel = new Hotel("Paradise", 1);
        }

        [Test]
        public void Test_BookingConstructorShouldRecieveBookingNumber()
        {
            int bookingNumber = 123456;

            booking = new Booking(bookingNumber, new Room(3, 33), 3);

            Assert.AreEqual(bookingNumber, booking.BookingNumber);
        }

        [Test]
        public void Test_BookingConstructorShouldRecieveNewRoom()
        {
            room = new Room(2, 25);

            booking = new Booking(11111, room, 5);

            Assert.AreEqual(room, booking.Room);
        }

        [Test]
        public void Test_BookingConstructorShouldRecieveResidenceDrutation()
        {
            int residenceDuration = 10;

            booking = new Booking(11111, new Room(5, 12), residenceDuration);

            Assert.AreEqual(residenceDuration, booking.ResidenceDuration);
        }

        [Test]
        public void Test_RoomConsutructor()
        {
            room = new Room(2, 25);

            Assert.AreEqual(2, room.BedCapacity);
            Assert.AreEqual(25, room.PricePerNight);
        }

        [Test]
        public void Test_RoomBedCapacity()
        {
            int bedCapacity = 3;

            room = new Room(bedCapacity, 5);

            Assert.AreEqual(bedCapacity, room.BedCapacity);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void Test_RoomBedCapactyShouldThrowExceptionIfValueIsBelowOrEqualToZero(int bedCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                room = new Room(bedCapacity, 5);
            });
        }

        [Test]
        public void Test_RoomSetPricePerNight()
        {
            int pricePerNight = 22;

            room = new Room(3, pricePerNight);

            Assert.AreEqual(pricePerNight, room.PricePerNight);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void Test_RoomPricePerNightShouldThrowExceptionIfValueIsBelowOrEqualToZero(int pricePerNight)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                room = new Room(3, pricePerNight);
            });
        }


        [Test]
        public void Test_HotelConstructor()
        {
            string hotelName = "Paradise";
            int category = 1;

            hotel = new Hotel(hotelName, category);

            Assert.AreEqual(hotelName, hotel.FullName);
            Assert.AreEqual(category, hotel.Category);
        }

        [Test]
        public void Test_HotelFullName()
        {
            string fullName = "Paradise";

            hotel = new Hotel(fullName, 1);

            Assert.AreEqual(fullName, hotel.FullName);
        }


        [TestCase("")]
        [TestCase("       ")]
        [TestCase(null)]
        public void Test_HotelFullNameShouldThrowExceptionIfNameIsNullOrWhiteSpace(string fullName)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                hotel = new Hotel(fullName, 1);
            });
        }

        [Test]
        public void Test_HotelCategory()
        {
            int category = 1;

            hotel = new Hotel("Paradise", 1);

            Assert.AreEqual(category, hotel.Category);
        }


        [TestCase(0)]
        [TestCase(-5)]
        [TestCase(6)]
        [TestCase(600)]
        public void Test_HotelCategoryShouldThrowExceptionIfValueIsBelowOneOrValueIsAboveFive(int category)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotel = new Hotel("Paradise", category);
            });
        }

        [Test]
        public void Test_HotelTurnover()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(2, 0, 5, 1000);

            int expectedTurnOver = 5 * 45;

            Assert.AreEqual(expectedTurnOver, hotel.Turnover);
        }

        [Test]
        public void Test_RoomsCollection()
        {
            hotel.AddRoom(room);
            hotel.AddRoom(room);
            hotel.AddRoom(room);

            int expectedCount = 3;

            Assert.AreEqual(expectedCount, hotel.Rooms.Count);
        }

        [Test]
        public void Test_BookingCollection()
        {
            hotel.AddRoom(room);
            hotel.AddRoom(room);
            hotel.AddRoom(room);

            hotel.BookRoom(2, 0, 5, 1000);
            hotel.BookRoom(2, 0, 5, 1000);
            hotel.BookRoom(2, 0, 5, 1000);

            int expectedBookingCount = 3;

            Assert.AreEqual(expectedBookingCount, hotel.Bookings.Count);
        }

    }
}
