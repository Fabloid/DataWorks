using System;
using RomanToInt.RomanNumber;

namespace RomanToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            string exit = null;
            while (exit != "n")
            {
                Console.Write("Введите римское число: ");
                string roman_number = Console.ReadLine();
                try
                {
                    Roman roman = new Roman(roman_number);
                    int num = roman.RomanToInt();
                    Console.WriteLine("Roman {0} = Int {1}", roman_number.ToUpper(), num);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.Write("Повторить? y/n: ");
                    exit = Console.ReadLine();
                }
            }
        }
    }
}
