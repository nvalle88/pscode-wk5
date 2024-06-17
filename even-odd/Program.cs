
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    public static List<EvenOrOdd> history = new List<EvenOrOdd>();

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
            Console.WriteLine("1. Verify is even or odd");
            Console.WriteLine("2. Hist");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("even or odd...");
                    VerifyEvenOrOdd();
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
        if (history.Count <= 0)
            Console.WriteLine("No elements in the list.");
        else
        {
            foreach (var item in history)
            {

                Console.WriteLine($"The number {item.Number} is {(item.IsEven ? "Even" : "Odd")}");
            }
        }
    }

    static void VerifyEvenOrOdd()
    {
        var isEven = false;
        Console.Write("Enter the number: ");
        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine("Invalid input for the number.");
            return;
        }

        isEven = number % 2 == 0;

        history.Add(new EvenOrOdd { Number = number, IsEven = isEven });
        Console.WriteLine($"The number {number} is {(isEven ? "Even" : "Odd")}");
    }
}

