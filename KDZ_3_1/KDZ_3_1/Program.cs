using System.Text.RegularExpressions;
using System.Text;
using ClassLibrary;
namespace KDZ_3_1;
// Григорьев Владимир, БПИ-237, 3 вариант.
class Program
{
    static void Main(string[] args)
    {
        // Повтор решения.
        do
        {
            Console.Clear();
            Methods.ColorPrint("Здравствуйте!", ConsoleColor.Yellow);
            Methods.ColorPrint("Вас приветствует программа обработки данных " +
                "json-файла.",
                ConsoleColor.Yellow);
            try
            {
                // Получение данных из файла или консоли.
                Customer[] customers = Menu.Choice();

                // Выполнение фильтрации или сортировки.
                Customer[] resultCustomers = Menu.FiltrOrSort(customers);
                // Вывод результата на консоль.
                Menu.Output(resultCustomers);

                // Запись результата в json-файл.
                JsonParser.WriteJson(resultCustomers);
                Console.WriteLine();

                Methods.ColorPrint("Программа успешно завершила работу!",
                    ConsoleColor.Green);
                Methods.ColorPrint("Если вы хотите завершить, нажмите Enter.\n" +
                    "Иначе другую клавишу.", ConsoleColor.Yellow);
            }
            // Обработка общих исключений
            catch (Exception ex)
            {
                Methods.ColorPrint($"Критическая ошибка: {ex.Message}",
                        ConsoleColor.Red);
                Methods.ColorPrint("Если вы хотите завершить, нажмите Enter.\n" +
                    "Иначе другую клавишу.", ConsoleColor.Yellow);
            }
        } while (Console.ReadKey().Key != ConsoleKey.Enter);
    }
}