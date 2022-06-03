using System;

namespace _01._2_PB_CSharp_First_Steps_in_Coding_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Кв. метри, които ще бъдат озеленени – реално число в интервала [0.00 … 10000.00]

            double meters = double.Parse(Console.ReadLine());
            //double pricePerMeter = 7.61;
            double allPrice = meters * 7.61; //pricePerMeter;
            double discount = allPrice * 18 / 100;
            double finalPrice = allPrice - discount;
            

            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");


            //  На конзолата се отпечатват два реда:
            //•	"The final price is: {крайна цена на услугата} lv."
            //•	"The discount is: {отстъпка} lv."

        }
    }
}

//Напишете програма, която изчислява необходимате сума, които Божидара ще трябва да заплати на фирмата
//Цената на един кв. м. е 7.61 лв със ДДС
//фирмата изпълнител предлага 18% отстъпка от крайната цена.