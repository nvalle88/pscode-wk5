
class Program
{
    public static List<Sum> historySum = new List<Sum>();
    static void Main()
    {
        RunMenu();
    }


    static void RunMenu()
    {
        bool continueProgram = true;

        while (continueProgram)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Sum");
            Console.WriteLine("2. Hist");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Sum...");
                    PerformAddition();
                    break;
                case "2":
                    Console.WriteLine("Hist...");
                    PrintHist();
                    break;
                case "3":
                    Console.WriteLine("Exiting the program.");
                    continueProgram = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter 1 or 2.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    static void PrintHist()
    {
        if (historySum.Count <= 0)
            Console.WriteLine("No elements in the list.");
        else
        {
            foreach (var item in historySum)
            {

                Console.WriteLine($"The sum of {item.number1} and {item.number2} is {item.sum}");
            }
        }
    }

    static void PerformAddition()
    {
        Console.WriteLine("Performing Addition:");
        Console.Write("Enter the first number: ");
        if (!double.TryParse(Console.ReadLine(), out double number1))
        {
            Console.WriteLine("Invalid input for the first number.");
            return;
        }

        Console.Write("Enter the second number: ");
        if (!double.TryParse(Console.ReadLine(), out double number2))
        {
            Console.WriteLine("Invalid input for the second number.");
            return;
        }
        double sum = number1 + number2;
        historySum.Add(new Sum { number1 = number1, number2 = number2, sum = sum });
        Console.WriteLine($"The sum of {number1} and {number2} is {sum}");
    }

}
