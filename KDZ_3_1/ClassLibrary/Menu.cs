using System;
using static System.Collections.Specialized.BitVector32;

namespace ClassLibrary
{
    /// <summary>
    /// Класс Меню программы.
    /// </summary>
	public static class Menu
	{
        /// <summary>
        /// Выбор способа получения данных.
        /// </summary>
        /// <returns></returns>
        public static Customer[] Choice()
        {
            Console.WriteLine("Выберите способ ввода данных (1/2):");
            Console.WriteLine("1. Ввести данные вручную.");
            Console.WriteLine("2. Прочитать из json-файла.");

            int n;
            do
            {
                n = Methods.InputNum();
                if (n != 1 && n != 2)
                {
                    Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
                        ConsoleColor.Red);
                }
            }
            while (n != 1 && n != 2);

            if (n == 1)
            {
                Customer[] customers = GetData.GetData_Manually();
                return customers;
            }
            else
            {
                Customer[] customers = JsonParser.ReadJson();
                return customers;
            }
        }

        /// <summary>
        /// Выбор операции.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public static Customer[] FiltrOrSort(Customer[] customers)
        {
            Console.Clear();
            Methods.ColorPrint("Данные успешно записаны.", ConsoleColor.Green);
            Console.WriteLine("Выберите операцию над данными (1/2):");
            Console.WriteLine("1. Фильтрация.");
            Console.WriteLine("2. Сортировка.");

            Customer[] resultCustomers = new Customer[0];

            //Customer[] resultCustomers = Filtration.FiltrProcessing(customers);
            //Customer[] resultCustomers = Sort.SortBool(customers);

            int n;
            do
            {
                n = Methods.InputNum();
                if (n != 1 && n != 2)
                {
                    Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
                        ConsoleColor.Red);
                }
            }
            while (n != 1 && n != 2);

            // Операция фильтрации.
            if (n == 1)
            {
                resultCustomers = Filtration.FiltrProcessing(customers);
            }
            // Операция сортировки.
            if (n == 2)
            {
                resultCustomers = Sort.SortProcessing(customers);
                resultCustomers = Sort.ReversOrNot(customers);
            }

            Methods.ColorPrint("Операция успешно выполнена!", ConsoleColor.Green);
            Console.WriteLine();
            

            return resultCustomers;
        }

        /// <summary>
        /// Вывод результата на консоль.
        /// </summary>
        /// <param name="customers"></param>
        public static void Output(Customer[] customers)
        {
            bool check = false;
            do
            {
                try
                {
                    Methods.ColorPrint("Давайте выведем таблицу на консоль.",
                        ConsoleColor.Yellow);
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("Нажмите Enter, чтобы продолжить." +
                            "\nЭтот текст, будет повторяться, пока не нажмете.");
                    }
                    while (Console.ReadKey().Key != ConsoleKey.Enter);
                    Console.WriteLine();

                    Methods.ColorPrint("Результат операции:", ConsoleColor.Green);

                    Console.WriteLine("ID;Name;Email;Age;City;Is_premium;Purchases;");
                    // Цикл вывода данных объектов массива.
                    for (int i = 0; i < customers.Length; i++)
                    {
                        Console.Write($"{customers[i].Customer_ID};");
                        Console.Write($"{customers[i].Name};");
                        Console.Write($"{customers[i].Email};");
                        Console.Write($"{customers[i].Age};");
                        Console.Write($"{customers[i].City};");
                        Console.Write($"{customers[i].Is_Premium};");
                        Console.Write("{");
                        for (int j = 0; j < customers[i].Purchases.Length; j++)
                        {
                            Console.Write(customers[i].Purchases[j]);
                            if (j != customers[i].Purchases.Length - 1)
                            {
                                Console.Write(";");
                            }
                        }
                        Console.Write("};");

                        Console.WriteLine();
                        check = true;
                    }
                }
                // Обработка исключений.
                catch (ArgumentException)
                {
                    Methods.ColorPrint("Вы ввели неверные данные, пожалуйста, повторите ввод.",
                        ConsoleColor.Red);
                    check = false;
                }
                catch (Exception ex)
                {
                    Methods.ColorPrint($"Критическая ошибка: {ex.Message}", ConsoleColor.Red);
                    Methods.ColorPrint("Повторите ввод.", ConsoleColor.Red);
                    check = false;
                }
            } while (!check);
        }
    }
}

