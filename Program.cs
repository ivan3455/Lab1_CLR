class Program
{
    public static string? testfield;
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine(
                "~~~Меню~~~\n" +
                "1. Вивести вказану кількість слів Lorem Ipsum\n" +
                "2. Виконати операцію взяття логарифму\n" +
                "3. Вихід з програми\n" +
                "Виберіть пункт меню: ");

            string input = Console.ReadLine();

            // Перевірка на ціле число
            if (!int.TryParse(input, out int menuSelection))
            {
                Console.WriteLine("Пункта меню не існує. Спробуйте ще.");
                continue;
            }

            switch (menuSelection)
            {
                case 1:
                    Console.WriteLine("Введіть кількість слів Lorem Ipsum, які ви хочете вивести на екран: ");
                    if (int.TryParse(Console.ReadLine(), out int wordCount))
                    {
                        PrintLoremIpsumWords(wordCount);
                    }
                    else
                    {
                        Console.WriteLine("Некоректний ввід.");
                    }
                    break;
                case 2:
                    Console.WriteLine("Ви вибрали Виконати операцію взяття логарифму");
                    PerformLogarithmOperation();
                    break;
                case 3:
                    // Вихід з програми
                    Console.WriteLine("До побачення!");
                    return;
                default:
                    Console.WriteLine("Некоректний ввід. Оберіть номер пункту зі списку.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void PrintLoremIpsumWords(int wordCount)
    {
        Console.Clear();
        string filePath = "C:\\Users\\User\\source\\repos\\Lab1_CLR\\data\\LoremIpsum.txt";
        if (File.Exists(filePath))
        {
            // Зчитування слів з файлу
            string[] words = File.ReadAllText(filePath)
                                  .Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(word => word.TrimEnd(',', '.', ':', ';'))
                                  .ToArray();
            if (wordCount <= words.Length)
            {
                Console.WriteLine(string.Join(" ", words, 0, wordCount));
            }
            else
            {
                Console.WriteLine($"Файл містить менше слів ({words.Length}) ніж ви запросили.");
            }
        }
        else
        {
            Console.WriteLine("Файл Lorem Ipsum не знайдено.");
        }
    }

    static void PerformLogarithmOperation()
    {
        Console.Clear();
        Console.WriteLine("Введіть число для обчислення логарифму:");
        if (double.TryParse(Console.ReadLine(), out double number) && number > 0)
        {
            // Обчислюємо логарифм введеного числа
            double result = Math.Log(number);
            Console.WriteLine($"Результат логарифму числа {number} = {result}");
        }
        else
        {
            Console.WriteLine("Некоректний ввід. Будь ласка, введіть додатне число.");
        }
    }
}
