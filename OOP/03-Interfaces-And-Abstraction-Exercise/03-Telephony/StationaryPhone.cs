using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Interfaces;

namespace Telephony
{
    public class StationaryPhone : ICallable

    {
        //string number;
        //public StationaryPhone(string number)
        //{
        //    this.number = number;   
        //}
        public void Call(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
            }

            Console.WriteLine($"Calling... {number}");
        }
    }
}
