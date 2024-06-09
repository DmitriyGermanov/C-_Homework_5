using Homework_5;

internal class Program
{
    private static void Main(string[] args)
    {
        ICalc calculator = new Calculator();

        calculator.GotResult += Calculator_GotResult!;
        Console.WriteLine("Оставьте поле пустым");
        bool exit = true;
        while (exit)
        {
            Console.WriteLine("Введите операцию вида: операция число или \"Отмена для отмены последней операции\"");
            string input = Console.ReadLine()!;
            string[] parts = input.Split(' ');
            if (parts.Length != 2)
            {
                if (input == "")
                {
                    exit = false;
                    break;
                }
                if (parts[0] != "Отмена")
                {
                    Console.WriteLine("Неверное количество аргументов.");
                    continue;
                }
            }
            int i = 0;
            if (parts.Count() > 1)
                i = int.TryParse(parts[1], out i) ? i : 0;
            Action action = parts[0] switch
            {
                "+" => () => calculator.Add(i),
                "-" => () => calculator.Sub(i),
                "*" => () => calculator.Mul(i),
                "/" => () => calculator.Div(i),
                "Отмена" => () => calculator.CancelLast(),
                _ => () => Console.WriteLine("Неверная операция.")
            };
            try { action(); } catch (Exception e) { Console.WriteLine("Деление на ноль невозможно."); }
        }

    }
    static void Calculator_GotResult(object sender, EventArgs e)
    {
        Console.WriteLine(((Calculator)sender).Result);
    }
}