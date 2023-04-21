using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartPhone = new Smartphone();
            StationaryPhone stationary = new StationaryPhone();

            foreach (var number in phoneNumbers)
            {
                if (number.Length==10)
                {
                    smartPhone.Call(number);
                }
                else if (number.Length==7)
                {
                    stationary.Call(number);
                }
            }
            
            foreach (var website in websites)
            {
                smartPhone.Browse(website);
            }
        }
    }
}
