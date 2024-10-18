using System;
using System.Text;
using System.Text.RegularExpressions;
namespace ClassLibrary
{
	public static class JsonParser
	{
		private static string jsonPath;

        /// <summary>
        /// Чтение данных типа Customer[] из json-файла.
        /// </summary>
        /// <returns></returns>
		public static Customer[] ReadJson()
		{
			Customer[] customers = new Customer[0];
            bool check = true;
            // Цикл, для корректности ввода json-файла.
			do
			{
				try
				{
					while (true)
					{
						Console.WriteLine("Введите АБСОЛЮТНЫЙ путь json-файла:");
						jsonPath = Console.ReadLine();

						if (jsonPath.Contains(".json"))
						{
							break;
						}
						else
						{
							Console.WriteLine();
							Methods.ColorPrint("Вы ввели файл с другим расширением." +
								"\nПовторите ввод.", ConsoleColor.Red);
							continue;
						}
					}

					Console.WriteLine();
					using StreamReader streamReader = new StreamReader(@jsonPath);
                    // Менятся поток чтения через файл.
                    Console.SetIn(streamReader);
                    StringBuilder stringBuilder = new StringBuilder();
                    string? data = Console.ReadLine()!;
                    // Чтение данных из файла.
                    while (!string.IsNullOrEmpty(data))
                    {
                        stringBuilder.Append(data);
                        data = Console.ReadLine();
                        stringBuilder.Append("\n");
                    }

					string pre_content = stringBuilder.ToString();
                    string content = pre_content[..^1];

                    // Проверка на пустой файл.
                    if (string.IsNullOrEmpty(content))
                    {
                        throw new ArgumentNullException("Файл пустой!");
                    }

                    // Проверка на json формат.
                    if (content[0] != '[' || content[^1] != ']')
                    {
                        throw new ArgumentNullException("Данные не удовлетворяют условиям " +
                            "json-файла!");
                    }

                    // Данные вносятся в массивы будущих полей будущих массивов.
					int[] customers_ID = GetData.Customers_id(content);
					string[] names = GetData.Names(content);
					string[] emails = GetData.Emails(content);
					int[] ages = GetData.Ages(content);
                    string[] cities = GetData.Cities(content);
                    bool[] is_premium = GetData.IsPremium(content);
                    string[][] purchases = GetData.Purchases(content);

                    // Перенаправление потока обратно через консоль.
                    Console.SetIn(new StreamReader(Console.OpenStandardInput()));

                    // Создание массивов объекта Customer.
                    if (customers_ID.Length != names.Length ||
                        names.Length != emails.Length ||
                        emails.Length != ages.Length || ages.Length != cities.Length ||
                        cities.Length != is_premium.Length ||
                        is_premium.Length != purchases.Length)
                    {
                        throw new ArgumentNullException("Количество полей не совпадает!");
                    }
                    else
                    {
                        Array.Resize(ref customers, customers_ID.Length);
                        for (int i = 0; i < customers.Length; i++)
                        {
                            customers[i] = new Customer(customers_ID[i], names[i], emails[i],
                                ages[i], cities[i], is_premium[i], purchases[i]);
                        }
                    }
				}
                // Обработка исключений.
                catch (ArgumentNullException ex)
                {
                    Methods.ColorPrint("Oшибка! Возможно, вы ввели не тот файл." +
                        "\nПовторите ввод." +
                        $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                    check = false;
                }
                catch (FileNotFoundException ex)
                {
                    Methods.ColorPrint("Ошибка! Файл не найден." +
                        "\nПовторите ввод." +
                        $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                    check = false;
                }
                catch (DirectoryNotFoundException ex)
                {
                    Methods.ColorPrint("Ошибка! Часть файла не найдена или " +
                        "его директория.\nПовторите ввод." +
                        $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                }
                catch (IOException ex)
                {
                    Methods.ColorPrint("Ошибка при открытии файла и чтении структуры!" +
                        "\nПовторите ввод." +
                        $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    Methods.ColorPrint($"Критическая ошибка: {ex.Message} " +
                        $"\nПовторите ввод.", ConsoleColor.Red);
                }
			} while (check == false);

            return customers;
		}

        //Альтернативное решение метода Write, которое снизу.
        //Вместо Write(Customer[] customers) можно создать string метод
        //CreateContent(Customer[] customers). 
        //Там создается StringBuilder sb, в которое постепенно добавляем все -
        //Строки json-файла (вместо Console.Write(smth); пишем sb.Append(smth);.
        //Превращаем sb в string content и возвращаем в метод WriteJson(Customr[] c).
        //После в WriteJson(Customer[] customers), при записи в файл через поток,
        //Мы можем написать Console.Write(content).

        /// <summary>
        /// Вывод даных типа Customer[].
        /// </summary>
        /// <param name="customers"></param>
        private static void Write(Customer[] customers)
        {
            Console.Write("[");
            // Цикл, для вывода данных всех объектов массива.
            for (int i = 0; i < customers.Length; i++)
            {
                Console.Write("\n  {");
                Console.Write($"\n    \"customer_id\": {customers[i].Customer_ID},");
                Console.Write($"\n    \"name\": \"{customers[i].Name}\",");
                Console.Write($"\n    \"email\": \"{customers[i].Email}\",");
                Console.Write($"\n    \"age\": {customers[i].Age},");
                Console.Write($"\n    \"city\": \"{customers[i].City}\",");
                string setBool;
                if (customers[i].Is_Premium)
                {
                    setBool = "true";
                }
                else
                {
                    setBool = "false";
                }
                Console.Write($"\n    \"is_premium\": {setBool},");
                Console.Write($"\n    \"purchases\": [");
                for (int j = 0; j < customers[i].Purchases.Length; j++)
                {
                    Console.Write($"\n      \"{customers[i].Purchases[j]}\"");
                    if (j != customers[i].Purchases.Length-1)
                    {
                        Console.Write(",");
                    }
                }
                Console.Write("\n    ]");
                Console.Write("\n  }");
                if (i != customers.Length-1)
                {
                    Console.Write(",");
                }
            }
            Console.Write("\n]");
        }

        /// <summary>
        /// Запись данных типа Customer[] в json-файл.
        /// </summary>
        /// <param name="customers"></param>
        public static void WriteJson(Customer[] customers)
        {
            Methods.ColorPrint("Хотите сохранить результат в json-файл (Да/Нет)?",
                ConsoleColor.Yellow);
            // Выбор: записывать результат в файл или нет.
            string choice = Methods.Choice();
            Console.WriteLine();

            if (choice.ToLower() == "да")
            {
                string choice1 = "";
                // Проверка, что данные были взяты из файла, а не вручную.
                if (jsonPath != null)
                {
                    Methods.ColorPrint("Хотите перезаписать данные в исходном файле (Да) " +
                    "или записать на новый файл (Нет)?", ConsoleColor.Yellow);
                    choice1 = Methods.Choice();
                }

                // Перезапись в исходный файл.
                if (choice1.ToLower() == "да" && jsonPath != null)
                {
                    TextWriter old = Console.Out;
                    using (StreamWriter streamWriter = new StreamWriter(@jsonPath, false))
                    {
                        Console.SetOut(streamWriter);
                        Write(customers);
                    }
                    Console.SetOut(old);
                    Methods.ColorPrint("Данные успешно записаны в файл!",
                        ConsoleColor.Green);
                }
                // Запись в новый файл.
                else
                {
                    Methods.ColorPrint("Создание или перезапись другого файла." +
                        "\nЕсли файла не существует, он создастся автоматически."+
                        "\nЕсли же введеный вами файл существует, то информация в нем " +
                        "поменяется!" +
                        "\nФайл должен иметь расширение .json", ConsoleColor.Yellow);
                    Console.WriteLine();
                    string newJsonPath;
                    bool check = false;
                    // Цикл для корректности ввода данных в json-файл.
                    do
                    {
                        try
                        {
                            while (true)
                            {
                                Console.WriteLine("Введите АБСОЛЮТНЫЙ путь json-файла:");
                                newJsonPath = Console.ReadLine();

                                if (newJsonPath.Contains(".json"))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Methods.ColorPrint("Вы ввели файл с другим расширением." +
                                        "\nПовторите ввод.", ConsoleColor.Red);
                                    continue;
                                }
                            }
                            // Перенаправление потока вывода через файл.
                            TextWriter old = Console.Out;
                            using (StreamWriter streamWriter = new StreamWriter(newJsonPath, false))
                            {
                                Console.SetOut(streamWriter);
                                Write(customers);
                            }
                            // Перенаправление потока вывода обратно через файл.
                            Console.SetOut(old);
                            Methods.ColorPrint("Данные успешно записаны в файл!",
                                ConsoleColor.Green);
                            check = true;
                        }
                        // Обработка исключений.
                        catch (ArgumentException ex)
                        {
                            Methods.ColorPrint("Введено неккоректное название файла, " +
                                "повторите попытку." +
                                $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                            check = false;
                        }
                        catch (IOException ex)
                        {
                            Methods.ColorPrint("Возникла ошибка при открытии файла и " +
                                "записи структуры, повторите попытку." +
                                $"\nКод ошибки: {ex.Message}", ConsoleColor.Red);
                            check = false;
                        }
                        catch (Exception ex)
                        {
                            Methods.ColorPrint($"Критическая ошибка: {ex.Message} " +
                                $"\nПовторите ввод.", ConsoleColor.Red);
                            check = false;
                        }
                    }
                    while (!check);
                }
            }
        }
    }
}