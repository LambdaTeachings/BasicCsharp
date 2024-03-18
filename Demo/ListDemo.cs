public static class ListDemo
{
    public static void Demo()
    {
        var list = new List<int>();
        var input = string.Empty;

        while (true)
        {
            Console.WriteLine($"Enter a number. Current count is {list.Count}.");
            Console.WriteLine($"enter 'a' for average, 's' for sum and 'm' for median");
            Console.WriteLine($"enter 'c' to clear console");
            input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                list.Add(result);
            }
            else if (input == "a")
            {
                ShowAverage(list);
            }
            else if (input == "s")
            {
                ShowSum(list);
            }
            else if (input == "m")
            {
                ShowMedian(list);
            }
            else if (input == "c")
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Not a valid input");
            }
        }
    }

    private static void ShowMedian(List<int> list)
    {
        list.Sort();

        Console.WriteLine($"Median is: {list[list.Count / 2]:n0}");
    }

    private static void ShowSum(List<int> list)
    {
        long sum = 0;

        foreach (var number in list)
            sum += number;

        Console.WriteLine($"Sum is: {sum:n0}");
    }

    private static void ShowAverage(List<int> list)
    {
        long sum = 0;

        foreach (var number in list)
            sum += number;

        Console.WriteLine($"Average is: {sum / list.Count :n2}");
    }
}
