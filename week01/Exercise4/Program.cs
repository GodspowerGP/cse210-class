using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            string response = Console.ReadLine();
            userNumber = int.Parse(response);
            
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        double average = ((double)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The largest number is: {max}");

        int minPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < minPositive)
            {
                minPositive = number;
            }
        }
        Console.WriteLine($"The smallest positive number is: {minPositive}");

        numbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}