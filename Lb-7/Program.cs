using System;
using System.Collections;
using System.Collections.Generic;

using Lb_7.Classes;

class Program
{
     public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CustomLinkedList<int> list = new CustomLinkedList<int>();
        bool running = true;

        // foreach (var element in list )
        // {
        //     
        // }
        while (running)
        {
            Console.WriteLine("\nВиберіть операцію:");
            Console.WriteLine("1. AddFirst");
            Console.WriteLine("2. AddLast");
            Console.WriteLine("3. RemoveFirst");
            Console.WriteLine("4. RemoveLast");
            Console.WriteLine("5. PrintList");
            Console.WriteLine("6. Exit");
            Console.Write("Ваш вибір: ");
            
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch ((ListOperations)choice)
                {
                    case ListOperations.AddFirst:
                        Console.Write("Введіть число для додавання на початок: ");
                        if (int.TryParse(Console.ReadLine(), out int value1))
                        {
                            list.AddFirst(value1);
                        }
                        else
                        {
                            Console.WriteLine("Неправильне значення.");
                        }
                        break;
                    
                    case ListOperations.AddLast:
                        Console.Write("Введіть число для додавання в кінець: ");
                        if (int.TryParse(Console.ReadLine(), out int value2))
                        {
                            list.AddLast(value2);
                        }
                        else
                        {
                            Console.WriteLine("Неправильне значення.");
                        }
                        break;
                    
                    case ListOperations.RemoveFirst:
                        list.RemoveFirst();
                        break;
                    
                    case ListOperations.RemoveLast:
                        list.RemoveLast();
                        break;
                    
                    case ListOperations.PrintList:
                        list.PrintList();
                        break;
                    
                    case ListOperations.Exit:
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Невірне значення, спробуйте ще раз.");
            }
        }

        Console.WriteLine("Програма завершена.");
    }
    public enum ListOperations
    {
        AddFirst = 1,
        AddLast,
        RemoveFirst,
        RemoveLast,
        PrintList,
        Exit
    }
}