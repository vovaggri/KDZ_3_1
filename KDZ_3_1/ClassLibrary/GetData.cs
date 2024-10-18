 using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    /// <summary>
    /// Класс получения данных
    /// </summary>
	public static class GetData
	{
        /// <summary>
        /// Ввод данных клиента вручную.
        /// </summary>
        /// <returns></returns>
        public static Customer[] GetData_Manually()
        {
            Console.Clear();
            Console.WriteLine("Формируем список клиентов.");
            Customer[] customers = new Customer[0];
            int count = 0;
            do
            {
                count++;
                Array.Resize(ref customers, count);
                Console.Write("Введите id клиента (формат натурального числа): ");
                int customer_id = Methods.InputNum();
                Console.Write("Введите имя клиента: ");
                string name = Methods.InputStr();
                Console.Write("Введите email клиента: ");
                string email = Methods.InputStr();
                Console.Write("Введите возраст клиента: ");
                int age = Methods.InputNum();
                Console.Write("Введите город откуда клиент: ");
                string city = Methods.InputStr();
                Console.Write("Введите premium статус клиента (true/false): ");
                bool is_premium = Methods.InputBool();
                string[] purchases = GeneratePurchasesList();

                customers[count - 1] = new Customer(customer_id, name, email, age, city,
                    is_premium, purchases);
                Methods.ColorPrint("Клиент успешно добавлен в список!",
                    ConsoleColor.Green);
                Console.WriteLine("Хотите добавить еще одного клиента в список?");
                Methods.ColorPrint("Для добаления еще одного клиента " +
                    "нажмите любую клавишу, кроме Escape.", ConsoleColor.Yellow);
                Methods.ColorPrint("Для завершения формирования списка клиентов " +
                    "нажмите клавишу Escape.", ConsoleColor.Yellow);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Methods.ColorPrint("Список клиентов успешно сформирован!",
                ConsoleColor.Green);
            return customers;
        }

        /// <summary>
        /// Создание списка покупок клиента.
        /// </summary>
        /// <returns></returns>
        private static string[] GeneratePurchasesList()
        {
            Methods.ColorPrint("Создаем список покупок клиента.",
                ConsoleColor.Yellow);
            string[] purchases = new string[0];
            int count = 0;
            do
            {
                count++;
                Array.Resize(ref purchases, count);
                Console.Write("Введите покупку клиента: ");
                purchases[count-1] = Methods.InputStr();
                Methods.ColorPrint("Покупка клиента успешно добавлена!",
                    ConsoleColor.Green);
                Console.WriteLine("У клиента есть еще покупки?");
                Methods.ColorPrint("Для добавления еще одной покупки " +
                    "нажмите любую клавишу, кроме Escape.", ConsoleColor.Yellow);
                Methods.ColorPrint("Для завершения добавления покупок клиента " +
                    "нажмите клавишу Escape.", ConsoleColor.Yellow);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Methods.ColorPrint("Покупки клиента успешно добавлены!",
                ConsoleColor.Green);
            return purchases;
        }

        /// <summary>
        /// Создание массива Customers_id из json-файла через регулярные выражения.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int[] Customers_id(string content)
        {
            Regex regex = new Regex("\"customer_id\":\\s[0-9]+,");
            MatchCollection matches = regex.Matches(content);
            var stringBuilder = new StringBuilder();

            string customers_ID_Str;
            int[] customers_ID = new int[0];

            if (matches.Count == 0)
            {
                throw new ArgumentNullException("Нет совпадений.");
            }
            else
            {
                Array.Resize(ref customers_ID, matches.Count);
                bool check;
                for (int i = 0; i < matches.Count; i++)
                {
                    string pre_value = matches[i].Value;
                    string value = pre_value[15..^1];
                    stringBuilder.Append(value);
                    if (i != matches.Count - 1)
                    {
                        stringBuilder.Append(",");
                    }
                }
                customers_ID_Str = stringBuilder.ToString();
                string[] customers_ID_Str_Arr = customers_ID_Str.Split(',');
                for (int i = 0; i < customers_ID_Str_Arr.Length; i++)
                {
                    check = int.TryParse(customers_ID_Str_Arr[i], out customers_ID[i]);
                    if (!check)
                    {
                        throw new ArgumentNullException();
                    }
                }
                return customers_ID;
            }
        }

        /// <summary>
        /// Создание массива Names из json-файла через регулярные выражения.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string[] Names(string content)
        {
            Regex regex = new Regex("\"name\":\\s\"[^\"]*\",");
            MatchCollection matches = regex.Matches(content);
            var stringBuilder = new StringBuilder();

            string names_str;
            string[] names;

            if (matches.Count == 0)
            {
                throw new ArgumentNullException("Нет совпадений.");
            }
            else
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    string pre_value = matches[i].Value;
                    string value = pre_value[9..^2];
                    stringBuilder.Append(value);
                    if (i != matches.Count - 1)
                    {
                        stringBuilder.Append(",");
                    }
                }
                names_str = stringBuilder.ToString();
                names = names_str.Split(',');
                return names;
            }
        }

        /// <summary>
        /// Создание массива Emails из json-файла через регулярные выражения.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string[] Emails(string content)
        {
            Regex regex = new Regex("\"email\":\\s\"[^\"]*\",");
            MatchCollection matches = regex.Matches(content);
            var stringBuilder = new StringBuilder();

            string emails_str;
            string[] emails;

            if (matches.Count == 0)
            {
                throw new ArgumentNullException("Нет совпадений.");
            }
            else
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    string pre_value = matches[i].Value;
                    string value = pre_value[10..^2];
                    stringBuilder.Append(value);
                    if (i != matches.Count - 1)
                    {
                        stringBuilder.Append(",");
                    }
                }
                emails_str = stringBuilder.ToString();
                emails = emails_str.Split(',');
                return emails;
            }
        }

        /// <summary>
        /// Создание массива Ages из json-файла через регулярные выражения.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int[] Ages(string content)
        {
            Regex regex = new Regex("\"age\":\\s[0-9]+,");
            MatchCollection matches = regex.Matches(content);
            var stringBuilder = new StringBuilder();

            string ages_str;
            int[] ages = new int[0];

            if (matches.Count == 0)
            {
                throw new ArgumentNullException("Нет совпадений.");
            }
            else
            {
                Array.Resize(ref ages, matches.Count);
                bool check;
                for (int i = 0; i < matches.Count; i++)
                {
                    string pre_value = matches[i].Value;
                    string value = pre_value[7..^1];
                    stringBuilder.Append(value);
                    if (i != matches.Count - 1)
                    {
                        stringBuilder.Append(",");
                    }
                }
                ages_str = stringBuilder.ToString();
                string[] customers_ID_Str_Arr = ages_str.Split(',');
                for (int i = 0; i < customers_ID_Str_Arr.Length; i++)
                {
                    check = int.TryParse(customers_ID_Str_Arr[i], out ages[i]);
                    if (!check)
                    {
                        throw new ArgumentNullException();
                    }
                }
                return ages;
            }
        }

        /// <summary>
        /// Создание массива Cities из json-файла через регулярные выражения.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string[] Cities(string content)
        {
            Regex regex = new Regex("\"city\":\\s\"[^\"]*\",");
            MatchCollection matches = regex.Matches(content);
            var stringBuilder = new StringBuilder();

            string cities_str;
            string[] cities;

            if (matches.Count == 0)
            {
                throw new ArgumentNullException("Нет совпадений.");
            }
            else
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    string pre_value = matches[i].Value;
                    string value = pre_value[9..^2];
                    stringBuilder.Append(value);
                    if (i != matches.Count - 1)
                    {
                        stringBuilder.Append(",");
                    }
                }
                cities_str = stringBuilder.ToString();
                cities = cities_str.Split(',');
                return cities;
            }
        }

        /// <summary>
        /// Создание массива Is_premium из json-файла через регулярные выражения.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool[] IsPremium(string content)
        {
            Regex regex = new Regex("\"is_premium\":\\s[A-Za-z]+,");
            MatchCollection matches = regex.Matches(content);
            var stringBuilder = new StringBuilder();

            string is_premium_str;
            bool[] is_premium = new bool[0];

            if (matches.Count == 0)
            {
                throw new ArgumentNullException("Нет совпадений.");
            }
            else
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    string pre_value = matches[i].Value;
                    string value = pre_value[14..^1];
                    stringBuilder.Append(value);
                    if (i != matches.Count - 1)
                    {
                        stringBuilder.Append(",");
                    }
                }
                Array.Resize(ref is_premium, matches.Count);
                is_premium_str = stringBuilder.ToString();
                string[] is_premium_str_arr = is_premium_str.Split(',');
                for (int i = 0; i < is_premium_str_arr.Length; i++)
                {
                    if (is_premium_str_arr[i] == "true")
                    {
                        is_premium[i] = true;
                    }
                    else if (is_premium_str_arr[i] == "false")
                    {
                        is_premium[i] = false;
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }
                return is_premium;
            }
        }

        /// <summary>
        /// Создание массива массивов Purchases из json-файла через регулярные выражения.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string[][] Purchases(string content)
        {
            Regex regex = new Regex("\"purchases\":\\s\\[[^\\]]*\\]");
            MatchCollection matches = regex.Matches(content);
            var stringBuilder = new StringBuilder();

            string pre_purchases_str;
            string[] pre_purchases_arr;
            string[][] pre_purchases = new string[0][];
            string[][] purchases = new string[0][];

            if (matches.Count == 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    string pre_value = matches[i].Value;
                    string value = pre_value[21..^6];
                    stringBuilder.Append(value);
                    if (i != matches.Count - 1)
                    {
                        stringBuilder.Append(";");
                    }
                }
                Array.Resize(ref pre_purchases, matches.Count);
                pre_purchases_str = stringBuilder.ToString();
                pre_purchases_arr = pre_purchases_str.Split(';');

                for (int i = 0; i < pre_purchases_arr.Length; i++)
                {
                    pre_purchases[i] = pre_purchases_arr[i].Split(",\n      ");
                }

                Array.Resize(ref purchases, matches.Count);
                for (int i = 0; i < pre_purchases.Length; i++)
                {
                    Array.Resize(ref purchases[i], pre_purchases[i].Length);
                    for (int j = 0; j < pre_purchases[i].Length; j++)
                    {
                        purchases[i][j] = pre_purchases[i][j][1..^1];
                    }
                }
                return purchases;
            }
        }
    }
}