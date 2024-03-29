﻿using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private readonly int bedCapacity;
        private double pricePerNight;
        public Room(int bedCapacity)
        {
            this.bedCapacity = bedCapacity;
            this.pricePerNight = 0;
        }

        public int BedCapacity => bedCapacity;

        public double PricePerNight 
        {
            get => pricePerNight;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;  
        }
    }
}
