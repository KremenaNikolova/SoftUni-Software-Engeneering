using System;
using System.Text;

namespace _04_Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            StringBuilder encencryptedMessage = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                int newChar = message[i] + 3;
                char everyCharrMessage = (char)newChar;
                encencryptedMessage.Append(everyCharrMessage);
            }

            Console.WriteLine(encencryptedMessage);
        }
    }
}
