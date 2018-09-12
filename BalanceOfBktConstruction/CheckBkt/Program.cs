using System;

namespace CheckBkt
{
    class Program
    {
        static void Main(string[] args)
        {
            string exit = null;
            while (exit!="n")
            {
                try
                {
                    Console.Write("Введите скобочную последовательность: ");
                    string bracket_construction = Console.ReadLine();
                    Console.WriteLine(BktStruct.Check(bracket_construction));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.Write("Повторить? (n для выхода): ");
                    exit = Console.ReadLine().ToLower();
                }
            }
            
        }        
    }
}
