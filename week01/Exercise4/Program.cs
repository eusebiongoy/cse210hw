using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> Numbers = new List<int>();

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");

            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            if (userNumber != 0)
            {
                Numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int number in Numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

       
        float average = ((float)sum) / Numbers.Count;
        Console.WriteLine($"The average is: {average}");

       
        int max = Numbers[0];

        foreach (int number in Numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}