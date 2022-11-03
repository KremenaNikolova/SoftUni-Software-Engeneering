using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Interfaces;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string website)
        {
            for (int i = 0; i < website.Length; i++)
            {
                if (char.IsDigit(website[i]))
                {
                    Console.WriteLine("Invalid URL!");
                    return;
                }
            }
            Console.WriteLine($"Browsing: {website}!");
        }

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
