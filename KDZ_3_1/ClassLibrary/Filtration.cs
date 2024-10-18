using System;
namespace ClassLibrary
{
	public static class Filtration
	{
        /// <summary>
        /// Изменение массива объектов Customer.
        /// </summary>
        /// <param name="filtrCustomers"></param>
        /// <param name="el_customer"></param>
        /// <param name="index"></param>
        private static void Insert(ref Customer[] filtrCustomers, Customer el_customer,
           int index)
        {
            Customer[] newCustomers = new Customer[filtrCustomers.Length + 1];
            newCustomers[index] = el_customer;

            for (int i = 0; i < index; i++)
            {
                newCustomers[i] = filtrCustomers[i];
            }

            for (int i = index; i < filtrCustomers.Length; i++)
            {
                newCustomers[i + 1] = filtrCustomers[i];
            }

            filtrCustomers = newCustomers;
        }

        /// <summary>
        /// Добавление элемента в массив объектов Customer.
        /// </summary>
        /// <param name="filtrCustomers"></param>
        /// <param name="el_customer"></param>
        private static void AddLast(ref Customer[] filtrCustomers, Customer el_customer)
        {
            Insert(ref filtrCustomers, el_customer, filtrCustomers.Length);
        }

        /// <summary>
        /// Фильтрация по полю Customer_ID.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        private static Customer[] FiltrCustomer_ID(Customer[] customers)
		{
			Customer[] filtrCustomers = new Customer[0];

            do
            {
                Console.WriteLine("Введите значение для фильтрации поля ID:");
                int value = Methods.InputNum();
                for (int i = 0; i < customers.Length; i++)
                {
                    if (customers[i].Customer_ID == value)
                    {
                        AddLast(ref filtrCustomers, customers[i]);
                    }
                }

                if (filtrCustomers.Length == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrCustomers.Length == 0);

            return filtrCustomers;
		}

        /// <summary>
        /// Фильтрация по полю Name.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        private static Customer[] FiltrCustomer_Name(Customer[] customers)
        {
            Customer[] filtrCustomers = new Customer[0];

            do
            {
                Console.WriteLine("Введите значение для фильтрации поля Name:");
                string value = Methods.InputStr();
                for (int i = 0; i < customers.Length; i++)
                {
                    if (customers[i].Name.Contains(value))
                    {
                        AddLast(ref filtrCustomers, customers[i]);
                    }
                }

                if (filtrCustomers.Length == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrCustomers.Length == 0);

            return filtrCustomers;
        }

        /// <summary>
        /// Фильтрация по полю Email.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        private static Customer[] FiltrCustomer_Email(Customer[] customers)
        {
            Customer[] filtrCustomers = new Customer[0];

            do
            {
                Console.WriteLine("Введите значение для фильтрации поля Email:");
                string value = Methods.InputStr();
                for (int i = 0; i < customers.Length; i++)
                {
                    if (customers[i].Email.Contains(value))
                    {
                        AddLast(ref filtrCustomers, customers[i]);
                    }
                }

                if (filtrCustomers.Length == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrCustomers.Length == 0);

            return filtrCustomers;
        }

        /// <summary>
        /// Фильтрация по полю Age.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        private static Customer[] FiltrCustomer_Age(Customer[] customers)
        {
            Customer[] filtrCustomers = new Customer[0];

            do
            {
                Console.WriteLine("Введите значение для фильтрации поля Age:");
                int value = Methods.InputNum();
                for (int i = 0; i < customers.Length; i++)
                {
                    if (customers[i].Age == value)
                    {
                        AddLast(ref filtrCustomers, customers[i]);
                    }
                }

                if (filtrCustomers.Length == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrCustomers.Length == 0);

            return filtrCustomers;
        }

        /// <summary>
        /// Фильтрация по полю City.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        private static Customer[] FiltrCustomer_City(Customer[] customers)
        {
            Customer[] filtrCustomers = new Customer[0];

            do
            {
                Console.WriteLine("Введите значение для фильтрации поля City:");
                string value = Methods.InputStr();
                for (int i = 0; i < customers.Length; i++)
                {
                    if (customers[i].City.Contains(value))
                    {
                        AddLast(ref filtrCustomers, customers[i]);
                    }
                }

                if (filtrCustomers.Length == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrCustomers.Length == 0);

            return filtrCustomers;
        }

        /// <summary>
        /// Фильтрация по полю Is_Premium.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        private static Customer[] FiltrCustomer_IsPremium(Customer[] customers)
        {
            Customer[] filtrCustomers = new Customer[0];

            do
            {
                Console.WriteLine("Введите значение для фильтрации" +
                    " поля Is_premium (true/false):");
                bool value = Methods.InputBool();

                for (int i = 0; i < customers.Length; i++)
                {
                    if (customers[i].Is_Premium == value)
                    {
                        AddLast(ref filtrCustomers, customers[i]);
                    }
                }

                if (filtrCustomers.Length == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrCustomers.Length == 0);

            return filtrCustomers;
        }

        /// <summary>
        /// Фильтрация по полю Purchases.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        private static Customer[] FiltrCustomer_Purchases(Customer[] customers)
        {
            Customer[] filtrCustomers = new Customer[0];

            do
            {
                Console.WriteLine("Введите значение для фильтрации поля Purchases");
                string value = Methods.InputStr();

                for (int i = 0; i < customers.Length; i++)
                {
                    for (int j = 0; j < customers[i].Purchases.Length; j++)
                    {
                        if (customers[i].Purchases[j] == value)
                        {
                            AddLast(ref filtrCustomers, customers[i]);
                            break;
                        }
                    }
                }

                if (filtrCustomers.Length == 0)
                {
                    Methods.ColorPrint("Данный элемент не найден." +
                        "\nВведите значение поля снова.", ConsoleColor.Red);
                }
            }
            while (filtrCustomers.Length == 0);

            return filtrCustomers;
        }

        /// <summary>
        /// Процесс фильтрации.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public static Customer[] FiltrProcessing(Customer[] customers)
        {
            Console.Clear();
            Methods.ColorPrint("Фильтрация.", ConsoleColor.Yellow);
            Methods.ColorPrint("Выберите цифру для какого поля" +
                " вы хотите сделать фильтрацию:", ConsoleColor.Yellow);
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
                if (n!=1 && n!=2 && n!=3 && n!=4 && n!=5 && n!=6 && n!=7)
                {
                    Console.WriteLine();
                    Methods.ColorPrint("Вы ввели некорректную цифру. Повторите ввод.",
                        ConsoleColor.Red);
                }
            }
            while (n!=1 && n!=2 && n != 3 && n != 4 && n != 5 && n != 6 && n != 7);

            Console.WriteLine();
            Customer[] filtrCustomers = new Customer[0];

            if (n == 1)
            {
                Methods.ColorPrint("Customer_ID.", ConsoleColor.Yellow);
                filtrCustomers = FiltrCustomer_ID(customers);
            }
            if (n == 2)
            {
                Methods.ColorPrint("Name.", ConsoleColor.Yellow);
                filtrCustomers = FiltrCustomer_Name(customers);
            }
            if (n == 3)
            {
                Methods.ColorPrint("Email.", ConsoleColor.Yellow);
                filtrCustomers = FiltrCustomer_Email(customers);
            }
            if (n == 4)
            {
                Methods.ColorPrint("Age.", ConsoleColor.Yellow);
                filtrCustomers = FiltrCustomer_Age(customers);
            }
            if (n == 5)
            {
                Methods.ColorPrint("City.", ConsoleColor.Yellow);
                filtrCustomers = FiltrCustomer_City(customers);
            }
            if (n == 6)
            {
                Methods.ColorPrint("Is_Premium.", ConsoleColor.Yellow);
                filtrCustomers = FiltrCustomer_IsPremium(customers);
            }
            if (n == 7)
            {
                Methods.ColorPrint("Purchases", ConsoleColor.Yellow);
                filtrCustomers = FiltrCustomer_Purchases(customers);
            }

            return filtrCustomers;
        }
    }
}