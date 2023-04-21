using System;

namespace _01_Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine()); //5
            int counter = 1;
            bool isBigger = false;

            for (int rows = 1; rows <= num; rows++) //redove =1; redovete sa po-malko ili ravno na 5; redovete=5+1;
            {
                for (int collums = 1; collums <= rows; collums++)// kolonite =1; dokato kolonite sa po-malki ili = na redovete (1); koloni=1+1;
                {                    
                    Console.Write($"{counter} "); //izpishi broqch 1
                    counter++; //broqch = 1+1;
                    if (counter > num)//ako broqcha e po-golqm ot num(5)
                    {
                        isBigger = true;
                        break;
                    }
                }
                Console.WriteLine();
                if (isBigger)
                {                    
                    break;
                }
            }
        }
    }
}
