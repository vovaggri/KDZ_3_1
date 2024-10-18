using System;
using System.Text;
namespace ClassLibrary
{
	public static class Sort
	{
		/// <summary>
		/// Сортировка для элементов массива Purchases.
		/// </summary>
		/// <param name="purchases"></param>
		/// <param name="i"></param>
		/// <param name="j"></param>
		/// <returns></returns>
		private static string[] SortPurchases(string[] purchases, int i, int j)
		{
			string temp = purchases[i];
			purchases[i] = purchases[j];
			purchases[j] = temp;
			return purchases;
		}

		/// <summary>
		/// Общая сортировка.
		/// </summary>
		/// <param name="customers"></param>
		/// <param name="i"></param>
		/// <param name="j"></param>
		/// <returns></returns>
		private static Customer[] Sorting(Customer[] customers, int i, int j)
		{
			Customer temp = customers[i];
			customers[i] = customers[j];
			customers[j] = temp;
			return customers;
		}

		/// <summary>
		/// Сортировка по string полям.
		/// </summary>
		/// <param name="customers"></param>
		/// <param name="field"></param>
		/// <returns></returns>
		private static Customer[] SortStr(Customer[] customers, int field)
		{
			// Сортировка по полю Name.
			if (field == 2)
			{
                Methods.ColorPrint("Name.", ConsoleColor.Yellow);
                for (int i = 0; i < customers.Length; i++)
				{
					for (int j = i+1; j < customers.Length; j++)
					{
						if (string.Compare(customers[i].Name, customers[j].Name) > 0)
						{
							customers = Sorting(customers, i, j);
						}
					}
				}
			}
            // Сортировка по полю Email.
            if (field == 3)
			{
                Methods.ColorPrint("Email.", ConsoleColor.Yellow);
                for (int i = 0; i < customers.Length; i++)
				{
					for (int j = i+1; j < customers.Length; j++)
					{
						if (string.Compare(customers[i].Email, customers[j].Email) >0)
						{
							customers = Sorting(customers, i, j);
						}
					}
				}
			}
            // Сортировка по полю City.
            if (field == 5)
			{
				Methods.ColorPrint("City.", ConsoleColor.Yellow);
                for (int i = 0; i < customers.Length; i++)
                {
                    for (int j = i+1; j < customers.Length; j++)
                    {
                        if (string.Compare(customers[i].City, customers[j].City) > 0)
                        {
                            customers = Sorting(customers, i, j);
                        }
                    }
                }
            }
            // Сортировка по полю Purchases.
            if (field == 7)
			{
                Methods.ColorPrint("Purchases.", ConsoleColor.Yellow);
                string[] purchases = new string[customers.Length];
				for (int i = 0; i < customers.Length; i++)
				{
                    var stringBuilder = new StringBuilder();
                    for (int j = 0; j < customers[i].Purchases.Length; j++)
					{
						stringBuilder.Append(customers[i].Purchases[j]);
						if (j != customers[i].Purchases.Length-1)
						{
							stringBuilder.Append(", ");
						}
					}
                    purchases[i] = stringBuilder.ToString();
                }

				for (int i = 0; i < purchases.Length; i++)
				{
					for (int j = i + 1; j < purchases.Length; j++)
					{
						if (string.Compare(purchases[i], purchases[j]) > 0)
						{
							purchases = SortPurchases(purchases, i, j);
							customers = Sorting(customers, i, j);
						}
					}
				}
			}
			return customers;
		}

        /// <summary>
        /// Сортировка по int полям.
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        private static Customer[] SortInt(Customer[] customers, int field)
		{
			// Сортировка по полю Customer_ID.
			if (field == 1)
			{
				Methods.ColorPrint("Customer_ID.", ConsoleColor.Yellow);
				for (int i = 0; i < customers.Length; i++)
				{
					for (int j = i+1; j < customers.Length; j++)
					{
						if (customers[i].Customer_ID > customers[j].Customer_ID)
						{
							customers = Sorting(customers, i, j);
						}
					}
				}
			}
            // Сортировка по полю Age.
            if (field == 4)
			{
                Methods.ColorPrint("Age.", ConsoleColor.Yellow);
                for (int i = 0; i < customers.Length; i++)
				{
					for (int j = i+1; j < customers.Length; j++)
					{
						if (customers[i].Age > customers[j].Age)
						{
							customers = Sorting(customers, i, j);
						}
					}
				}
			}
			return customers;
		}

		/// <summary>
		/// Сортировка bool поля Is_Premium.
		/// </summary>
		/// <param name="customers"></param>
		/// <returns></returns>
		private static Customer[] SortBool(Customer[] customers)
		{
            Methods.ColorPrint("Is_Premium.", ConsoleColor.Yellow);
            for (int i = 0; i < customers.Length; i++)
			{
				for (int j = i+1; j < customers.Length; j++)
				{
					if (customers[i].Is_Premium && !customers[j].Is_Premium)
					{
						customers = Sorting(customers, i, j);
					}
				}
			}
			return customers;
		}

		/// <summary>
		/// Процесс сортировки.
		/// </summary>
		/// <param name="customers"></param>
		/// <returns></returns>
		public static Customer[] SortProcessing(Customer[] customers)
		{
			Console.Clear();
			Methods.ColorPrint("Сортировка.", ConsoleColor.Yellow);
			Methods.ColorPrint("Выберите цифру для какого поля" +
				" вы хотите сделать сортировку:", ConsoleColor.Yellow);
			Methods.ColorPrint("1. Customer_ID.", ConsoleColor.Yellow);
			Methods.ColorPrint("2. Name.", ConsoleColor.Yellow);
			Methods.ColorPrint("3. Email.", ConsoleColor.Yellow);
			Methods.ColorPrint("4. Age.", ConsoleColor.Yellow);
			Methods.ColorPrint("5. City.", ConsoleColor.Yellow);
			Methods.ColorPrint("6. Is_Premium.", ConsoleColor.Yellow);
			Methods.ColorPrint("7. Purchases.", ConsoleColor.Yellow);

			int n;
			do
			{
				n = Methods.InputNum();
				if (n != 1 && n != 2 && n != 3 && n != 4 && n != 5 && n != 6 && n != 7)
				{
					Console.WriteLine();
					Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
						ConsoleColor.Red);
				}
			}
			while (n != 1 && n != 2 && n != 3 && n != 4 && n != 5 && n != 6 && n != 7);

			Console.WriteLine();
			Customer[] sortCustomers = new Customer[0];

			if (n == 1 || n == 4)
			{
				sortCustomers = SortInt(customers, n);
			}

			if (n == 2 || n == 3 || n == 5 || n == 7)
			{
				sortCustomers = SortStr(customers, n);
			}

			if (n == 6)
			{
				sortCustomers = SortBool(customers);
			}

			return sortCustomers;
		}

		/// <summary>
		/// Выбор сортировки прямого порядка или обратного.
		/// </summary>
		/// <param name="customers"></param>
		/// <returns></returns>
		public static Customer[] ReversOrNot(Customer[] customers)
		{
			Methods.ColorPrint("Как вы хотите отсортировать, в прямом порядке или " +
				"обратном (1/2)?", ConsoleColor.Yellow);
			Methods.ColorPrint("1. Прямой порядок.", ConsoleColor.Yellow);
			Methods.ColorPrint("2. Обратный порядок.", ConsoleColor.Yellow);

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
				return customers;
			}
			else
			{
				Array.Reverse(customers);
				return customers;
			}
        }
	}
}