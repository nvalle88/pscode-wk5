
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    public static List<Operation> history = new List<Operation>();
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
            Console.WriteLine("1. Operations");
            Console.WriteLine("2. Hist");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Operations...");
                    Operations();
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
                    Console.WriteLine("Invalid option. Please enter 1 or 3.");
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
            WriteOperations(history);
        }
    }

    static void Operations()
    {
        List<int> ListNumbers = new List<int>();
        Console.Write("Enter the quantity of numbers you wish to evaluate: ");
        if (!int.TryParse(Console.ReadLine(), out int numberOfelemnt))
        {
            Console.WriteLine("Invalid input for the first number.");
            return;
        }

        for (int i = 0; i < numberOfelemnt; i++)
        {
            Console.WriteLine("Enter the number:");
            var n = Console.ReadLine();
            if (int.TryParse(n, out int itemNumber))
                ListNumbers.Add(itemNumber);
            else
            {
                Console.WriteLine("Invalid input for the first number.");
                Console.WriteLine("Please try again.");
                i--;
            }
        }


        var average =  Convert.ToDouble(ListNumbers.Sum())/ ListNumbers.Count;
        var listSort = BubbleSort(ListNumbers);
        //var minimum = ListNumbers.OrderBy(x => x).FirstOrDefault();
        //var maximun = ListNumbers.OrderBy(x => x).LastOrDefault();
        var minimum = ListNumbers.FirstOrDefault();
        var maximun = ListNumbers.LastOrDefault();

        var operation = new Operation
        {
            Average = average,
            Minimum = minimum,
            Maximun = maximun,
            Numbers = ListNumbers
        };
        history.Add(operation);
        WriteOperations(new List<Operation> { operation });
    }
    static List<int> BubbleSort(List<int> list)
    {
        int n = list.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    int temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
        return list;
    }
    static void WriteOperations(List<Operation> history)
    {
        foreach (var item in history)
        {
            Console.WriteLine($"The numbers are: [{string.Join(",", item.Numbers)}]");
            Console.WriteLine($"Average: {item.Average}");
            Console.WriteLine($"Minimum: {item.Minimum}");
            Console.WriteLine($"Maximum: {item.Maximun}");
            Console.WriteLine($"-------------------------");
        }

    }


}
