using System;
namespace ClassLibrary
{
	public static class Methods
	{
        /// <summary>
        /// Цветной вывод текста в консоль.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void ColorPrint(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Ввод int переменной.
        /// </summary>
        /// <returns></returns>
        public static int InputNum()
        {
            int n;
            bool check;
            do
            {
                check = int.TryParse(Console.ReadLine(), out n);
                if (!check || n <= 0)
                {
                    ColorPrint("Неверный ввод! Повторите попытку.", ConsoleColor.Red);
                }
            }
            while (!check || n <= 0);
            return n;
        }

        /// <summary>
        /// Ввод string переменной.
        /// </summary>
        /// <returns></returns>
        public static string InputStr()
        {
            string str;
            bool check = false;
            do
            {
                str = Console.ReadLine();
                if (str == null)
                {
                    ColorPrint("Значение null!" +
                        "\nВведите значение снова.", ConsoleColor.Red);
                }
                else
                {
                    check = true;
                }
            }
            while (!check);
            return str;
        }

        /// <summary>
        /// Ввод bool переменной.
        /// </summary>
        /// <returns></returns>
        public static bool InputBool()
        {
            bool expression = false;
            bool check = false;
            do
            {
                string expression_str = Console.ReadLine();
                if (expression_str == "true")
                {
                    expression = true;
                    check = true;
                }
                else if (expression_str == "false")
                {
                    check = true;
                }
                else
                {
                    ColorPrint("Вы ввели неверное значение!" +
                        "\nВведите premium статус снова:", ConsoleColor.Red);
                }
            }
            while (!check);
            return expression;
        }

        /// <summary>
        /// Выбор между Да/Нет.
        /// </summary>
        /// <returns></returns>
        public static string Choice()
        {
            string choice;
            do
            {
                choice = InputStr();
                if (choice.ToLower() != "да" && choice.ToLower() != "нет")
                {
                    ColorPrint("Вы ввели неверное значение! Повторите ввод.",
                        ConsoleColor.Red);
                }
            }
            while (choice.ToLower() != "да" && choice.ToLower() != "нет");
            return choice;
        }
    }
}

