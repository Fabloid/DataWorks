using System;
using System.Linq;
using DoublyLinkedList.MyList;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDoublyLinkedList<object> list = new MyDoublyLinkedList<object>();
            string key = null;
            while (key!="0")
            {
                Console.Clear();
                Console.WriteLine("Значений в списке: {0}", list.Count());
                Console.Write("1-Добавить в начало\n2-Добавить в конец\n3-Перевернуть\n4-Вывести на экран\nВыберите действие (0 для выхода): ");
                key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите значение:");
                            list.AddFirst(Console.ReadLine());
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите значение:");
                            list.AddLast(Console.ReadLine());
                            break;
                        }
                    case "3":
                        {
                            list.Reverse();
                            break;
                        }
                    case "4":
                        {
                            foreach (var item in list)
                            {
                                Console.WriteLine(item);
                            }
                            Console.Write("Нажмите любую кнопку");
                            Console.ReadKey();
                            break;
                        }
                }                
            }
        }
    }
}
