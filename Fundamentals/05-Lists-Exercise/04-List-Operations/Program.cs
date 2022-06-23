using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();
                string[] token=command.Split();

                if (command=="End")
                {
                    break;
                }
                else if (token[0]=="Add")
                {
                    int numberForAdd = int.Parse(token[1]);
                    input.Add(numberForAdd);
                }
                else if (token[0]=="Insert")
                {
                    int numberForInsert = int.Parse(token[1]);
                    int indexWhereToInsert = int.Parse(token[2]);
                    input.Insert(indexWhereToInsert, numberForInsert);
                }
                else if (token[0]=="Remove")
                {
                    int removeNumberAtThisIndex = int.Parse(token[1]);
                    if (removeNumberAtThisIndex>input.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        input.RemoveAt(removeNumberAtThisIndex);
                    }
                }
                else if(token[0]=="Shift" && token[1] == "left")
                {
                    int counterForMoving=int.Parse (token[2]);
                    for (int i = 0; i < counterForMoving ; i++)
                    {
                        int numberForMoveToLeft = input[0];
                        input.RemoveAt(0);
                        input.Add(numberForMoveToLeft);
                    }
                }
                else if (token[0] == "Shift" && token[1] == "right")
                {
                    int counterForMoving = int.Parse(token[2]);
                    for (int i = 0; i < counterForMoving; i++)
                    {
                        int numberForMoveToRight = input[input.Count-1];
                        input.RemoveAt(input.Count-1);
                        //int position = input[0];
                        input.Insert(0, numberForMoveToRight);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            Console.WriteLine(string.Join(" ",input));
        }
    }
}
