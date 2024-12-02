// To see puzzle description, see README

// Time complexity: O(n * m), where n is the amount of lines and m is the amount of numbers per line

using System;
using System.Collections.Generic;

class Day2Part1_2024
{
    public static void ExecuteDay2Part1()
    {
        // Define and read input
        string day2Input = "Solutions/2024/Day2/Inputs/Day2Input.txt";

        string[] inputData = File.ReadAllLines(day2Input);

        int safeCounter = 0;


        foreach (var line in inputData)
        {
            // Split the line into numbers and convert them to integers
            var numbers = line.Split(' ').Select(int.Parse).ToList();

            // Put line into list, and subtract element 0 from element 1, element 1 from element 2 etc.
            var results = new List<int>();
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                results.Add(numbers[i + 1] - numbers[i]);
            }

            // Check if the resulting numbers pass these conditions
            bool isSafe = true;
            bool isPositive = results.All(x => x > 0);
            bool isNegative = results.All(x => x < 0);

            // Check if all resulting numbers are all positive or negative (meaning they all ascend or descend), fail it not
            if (!(isPositive || isNegative)) 
            {
                isSafe = false;
            }

            // Check if all resulting numbers are not 0, higher then 3 or lower then -3 (meaning that they all are in the range of 1 to 3). fail if not
            if (results.Any(x => x == 0 || x < -3 || x > 3))
            {
                isSafe = false;
            }

            // If the line passes the conditions, add 1 to the safe counter
            if (isSafe)
            {
                safeCounter++;
            }
        }

        // Display the safe counter
        Console.WriteLine($"Safe Number: {safeCounter}");
    }
}